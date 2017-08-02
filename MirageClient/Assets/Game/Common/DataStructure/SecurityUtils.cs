using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Security;
using System.Security.Permissions;
using UnityEngine;

namespace Mirage.DataStructure
{
    internal static class SecurityUtils 
    {
        private static volatile ReflectionPermission memberAccessPermission = null;
        private static volatile ReflectionPermission restrictedMemberAccessPermission = null;

        private static ReflectionPermission MemberAccessPermission
        {
            get
            {
                if (memberAccessPermission == null)
                {
                    memberAccessPermission = new ReflectionPermission(ReflectionPermissionFlag.MemberAccess);
                }
                return memberAccessPermission;
            }
        }

        private static ReflectionPermission RestrictedMemberAccessPermission
        {
            get
            {
                if (restrictedMemberAccessPermission == null)
                {
                    restrictedMemberAccessPermission = new ReflectionPermission(ReflectionPermissionFlag.RestrictedMemberAccess);
                }
                return restrictedMemberAccessPermission;
            }
        }

        private static void DemandReflectionAccess(Type type)
        {
            try
            {
                MemberAccessPermission.Demand();
            }
            catch (SecurityException)
            {
                DemandGrantSet(type.Assembly);
            }
        }

        [SecuritySafeCritical]
        private static void DemandGrantSet(Assembly assembly)
        {
            // I can do nothing in here! 
            //PermissionSet targetGrantSet = assembly.PermissionSet;
            //targetGrantSet.AddPermission(RestrictedMemberAccessPermission);
            //targetGrantSet.Demand();
        }

        private static bool HasReflectionPermission(Type type)
        {
            try
            {
                DemandReflectionAccess(type);
                return true;
            }
            catch (SecurityException)
            {
            }

            return false;
        }

        internal static object SecureCreateInstance(Type type)
        {
            return SecureCreateInstance(type, null, false);
        }

        internal static object SecureCreateInstance(Type type, object[] args, bool allowNonPublic)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }

            BindingFlags flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.CreateInstance;

            // if it's an internal type, we demand reflection permission.
            if (!type.IsVisible)
            {
                DemandReflectionAccess(type);
            }
            else if (allowNonPublic && !HasReflectionPermission(type))
            {
                // Someone is trying to instantiate a public type in *our* assembly, but does not
                // have full reflection permission. We shouldn't pass BindingFlags.NonPublic in this case.
                // The reason we don't directly demand the permission here is because we don't know whether
                // a public or non-public .ctor will be invoked. We want to allow the public .ctor case to
                // succeed.
                allowNonPublic = false;
            }

            if (allowNonPublic)
            {
                flags |= BindingFlags.NonPublic;
            }

            return Activator.CreateInstance(type, flags, null, args, null);
        }
    }
}