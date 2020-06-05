#pragma once
#include "pch.h"
#include <math.h>
#include <stdexcept>

using namespace std;

namespace DynamicLib
{
	extern "C" { __declspec(dllexport) double sum(double num1, double num2); }
	extern "C" { __declspec(dllexport) double dif(double num1, double num2); }
	extern "C" { __declspec(dllexport) double mult(double num1, double num2); }
	extern "C" { __declspec(dllexport) double div(double num1, double num2); }
}