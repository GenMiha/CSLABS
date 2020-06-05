#include "pch.h"
#include <limits.h>
#include "BlankDLL.h"
#include <math.h>

namespace DynamicLib
{
	double sum(double num1, double num2)
	{
		double result = num1 + num2;
		return result;
	}

	double dif(double num1, double num2)
	{
		double result = num1 - num2;
		return result;
	}

	double mult(double num1, double num2)
	{
		double result = num1 * num2;
		return result;
	}

	double div(double num1, double num2)
	{
		double result = num1 / num2;
		return result;
	}
}