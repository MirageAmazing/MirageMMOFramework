using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using ParadoxNotion.Design;
using UnityEngine;

namespace FlowCanvas.Nodes{

	[Category("Functions/Math")]
	[Name("Is Valid")]
	public class IsNotNull : PureFunctionNode<bool, object>{
		public override bool Invoke(object OBJECT){
			return OBJECT != null; 
		}
	}


	////////////////////////////////////////
	////////////ANY COMPARABLE//////////////
	////////////////////////////////////////

	[Category("Functions/Math/Any")]
	[Name(">")]
	public class AnyGreaterThan : PureFunctionNode<bool, IComparable, IComparable>{
		public override bool Invoke(IComparable a, IComparable b){
			return a.CompareTo(b) == 1;
		}
	}

	[Category("Functions/Math/Any")]
	[Name(">=")]
	public class AnyGreaterEqualThan : PureFunctionNode<bool, IComparable, IComparable>{
		public override bool Invoke(IComparable a, IComparable b){
			return a.CompareTo(b) == 1 || object.Equals(a, b);
		}
	}

	[Category("Functions/Math/Any")]
	[Name("<")]
	public class AnyLessThan : PureFunctionNode<bool, IComparable, IComparable>{
		public override bool Invoke(IComparable a, IComparable b){
			return a.CompareTo(b) == -1;
		}
	}

	[Category("Functions/Math/Any")]
	[Name("<=")]
	public class AnyLessEqualThan : PureFunctionNode<bool, IComparable, IComparable>{
		public override bool Invoke(IComparable a, IComparable b){
			return a.CompareTo(b) == -1 || object.Equals(a, b);
		}
	}

	[Category("Functions/Math/Any")]
	[Name("==")]
	public class AnyEqual : PureFunctionNode<bool, object, object>{
		public override bool Invoke(object a, object b){
			return object.Equals(a, b);
		}
	}

	[Category("Functions/Math/Any")]
	[Name("!=")]
	public class AnyNotEqual : PureFunctionNode<bool, object, object>{
		public override bool Invoke(object a, object b){
			return !object.Equals(a, b);
		}
	}





	////////////////////////////////////////
	///////////////FLOATS///////////////////
	////////////////////////////////////////

	[Category("Functions/Math/Floats")]
	[Name("+")]
	public class FloatAdd : PureFunctionNode<float, float, float>{
		public override float Invoke(float a, float b){
			return a + b;
		}
	}

	[Category("Functions/Math/Floats")]
	[Name("-")]
	public class FloatSubtract : PureFunctionNode<float, float, float>{
		public override float Invoke(float a, float b){
			return a - b;
		}
	}

	[Category("Functions/Math/Floats")]
	[Name("*")]
	public class FloatMultiply : PureFunctionNode<float, float, float>{
		public override float Invoke(float a, float b){
			return a * b;
		}
	}

	[Category("Functions/Math/Floats")]
	[Name("÷")]
	public class FloatDivide : PureFunctionNode<float, float, float>{
		public override float Invoke(float a, float b){
			return a / b;
		}
	}

	[Category("Functions/Math/Floats")]
	[Name("%")]
	public class FloatModulo : PureFunctionNode<float, float, float>{
		public override float Invoke(float value, float mod){
			return value % mod;
		}
	}

	[Category("Functions/Math/Floats")]
	[Name(">")]
	public class FloatGreaterThan : PureFunctionNode<bool, float, float>{
		public override bool Invoke(float a, float b){
			return a > b;
		}
	}

	[Category("Functions/Math/Floats")]
	[Name(">=")]
	public class FloatGreaterEqualThan : PureFunctionNode<bool, float, float>{
		public override bool Invoke(float a, float b){
			return a >= b;
		}
	}

	[Category("Functions/Math/Floats")]
	[Name("<")]
	public class FloatLessThan : PureFunctionNode<bool, float, float>{
		public override bool Invoke(float a, float b){
			return a < b;
		}
	}

	[Category("Functions/Math/Floats")]
	[Name("<=")]
	public class FloatLessEqualThan : PureFunctionNode<bool, float, float>{
		public override bool Invoke(float a, float b){
			return a <= b;
		}
	}

	[Category("Functions/Math/Floats")]
	[Name("==")]
	public class FloatEqual : PureFunctionNode<bool, float, float>{
		public override bool Invoke(float a, float b){
			return a == b;
		}
	}

	[Category("Functions/Math/Floats")]
	[Name("!=")]
	public class FloatNotEqual : PureFunctionNode<bool, float, float>{
		public override bool Invoke(float a, float b){
			return a != b;
		}
	}

	[Category("Functions/Math/Floats")]
	[Name("Invert")]
	public class FloatInvert : PureFunctionNode<float, float>{
		public override float Invoke(float value){
			return value * -1;
		}
	}




	////////////////////////////////////////
	///////////////INTEGER//////////////////
	////////////////////////////////////////

	[Category("Functions/Math/Integers")]
	[Name("+")]
	public class IntegerAdd : PureFunctionNode<int, int, int>{
		public override int Invoke(int a, int b){
			return a + b;
		}
	}

	[Category("Functions/Math/Integers")]
	[Name("-")]
	public class IntegerSubtract : PureFunctionNode<int, int, int>{
		public override int Invoke(int a, int b){
			return a - b;
		}
	}

	[Category("Functions/Math/Integers")]
	[Name("*")]
	public class IntegerMultiply : PureFunctionNode<int, int, int>{
		public override int Invoke(int a, int b){
			return a * b;
		}
	}

	[Category("Functions/Math/Integers")]
	[Name("÷")]
	public class IntegerDivide : PureFunctionNode<int, int, int>{
		public override int Invoke(int a, int b){
			return b == 0? 0 : a / b;
		}
	}

	[Category("Functions/Math/Integers")]
	[Name("%")]
	public class IntegerModulo : PureFunctionNode<int, int, int>{
		public override int Invoke(int value, int mod){
			return value % mod;
		}
	}


	[Category("Functions/Math/Integers")]
	[Name(">")]
	public class IntegerGreaterThan : PureFunctionNode<bool, int, int>{
		public override bool Invoke(int a, int b){
			return a > b;
		}
	}

	[Category("Functions/Math/Integers")]
	[Name(">=")]
	public class IntegerGreaterEqualThan : PureFunctionNode<bool, int, int>{
		public override bool Invoke(int a, int b){
			return a >= b;
		}
	}

	[Category("Functions/Math/Integers")]
	[Name("<")]
	public class IntegerLessThan : PureFunctionNode<bool, int, int>{
		public override bool Invoke(int a, int b){
			return a < b;
		}
	}

	[Category("Functions/Math/Integers")]
	[Name("<=")]
	public class IntegerLessEqualThan : PureFunctionNode<bool, int, int>{
		public override bool Invoke(int a, int b){
			return a <= b;
		}
	}

	[Category("Functions/Math/Integers")]
	[Name("==")]
	public class IntegerEqual : PureFunctionNode<bool, int, int>{
		public override bool Invoke(int a, int b){
			return a == b;
		}
	}

	[Category("Functions/Math/Integers")]
	[Name("!=")]
	public class IntegerNotEqual : PureFunctionNode<bool, int, int>{
		public override bool Invoke(int a, int b){
			return a != b;
		}
	}

	[Category("Functions/Math/Integers")]
	[Name("Invert")]
	public class IntegerInvert : PureFunctionNode<int, int>{
		public override int Invoke(int value){
			return value * -1;
		}
	}






	////////////////////////////////////////
	///////////////VECTORS//////////////////
	////////////////////////////////////////

	[Category("Functions/Math/Vector3")]
	[Name("==")]
	public class Vector3Equal : PureFunctionNode<bool, Vector3, Vector3>{
		public override bool Invoke(Vector3 a, Vector3 b){
			return a == b;
		}
	}

	[Category("Functions/Math/Vector3")]
	[Name("!=")]
	public class Vector3NotEqual : PureFunctionNode<bool, Vector3, Vector3>{
		public override bool Invoke(Vector3 a, Vector3 b){
			return a != b;
		}
	}

	[Category("Functions/Math/Vector3")]
	[Name("+")]
	public class Vector3Add : PureFunctionNode<Vector3, Vector3, Vector3>{
		public override Vector3 Invoke(Vector3 a, Vector3 b){
			return a + b;
		}
	}

	[Category("Functions/Math/Vector3")]
	[Name("-")]
	public class Vector3Subtract : PureFunctionNode<Vector3, Vector3, Vector3>{
		public override Vector3 Invoke(Vector3 a, Vector3 b){
			return a - b;
		}
	}

	[Category("Functions/Math/Vector3")]
	[Name("*")]
	public class Vector3Multiply : PureFunctionNode<Vector3, Vector3, float>{
		public override Vector3 Invoke(Vector3 a, float b){
			return a * b;
		}
	}

	[Category("Functions/Math/Vector3")]
	[Name("÷")]
	public class Vector3Divide : PureFunctionNode<Vector3, Vector3, float>{
		public override Vector3 Invoke(Vector3 a, float b){
			return a / b;
		}
	}





	////////////////////////////////////////
	///////////////BOOLEAN//////////////////
	////////////////////////////////////////

	[Category("Functions/Math/Boolean")]
	[Name("==")]
	public class BooleanEqual : PureFunctionNode<bool, bool, bool>{
		public override bool Invoke(bool a, bool b){
			return a == b;
		}
	}

	[Category("Functions/Math/Boolean")]
	[Name("!=")]
	public class BooleanNotEqual : PureFunctionNode<bool, bool, bool>{
		public override bool Invoke(bool a, bool b){
			return a != b;
		}
	}

	[Category("Functions/Math/Boolean")]
	public class AND : PureFunctionNode<bool, bool, bool>{
		public override bool Invoke(bool a, bool b){
			return a && b;
		}
	}

	[Category("Functions/Math/Boolean")]
	public class OR : PureFunctionNode<bool, bool, bool>{
		public override bool Invoke(bool a, bool b){
			return a || b;
		}
	}

	[Category("Functions/Math/Boolean")]
	public class NOT : PureFunctionNode<bool, bool>{
		public override bool Invoke(bool value){
			return !value;
		}
	}

	[Category("Functions/Math/Boolean")]
	public class XOR : PureFunctionNode<bool, bool, bool>{
		public override bool Invoke(bool a, bool b){
			return (a || b) && (a != b);
		}
	}
}