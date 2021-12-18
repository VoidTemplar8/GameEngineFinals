#define EXPORT_API __declspec(dllexport)

#include <iostream>

// Link following functions C-style (required for plugins)
extern "C"
{

	// The functions we will call from Unity.
	//
	int EXPORT_API ChangeColour()
	{
		return 1;
	}

} // end of export C block

/*int main() {

	std::cout << AddTwoFloats(2.5, 5.5);
}*/