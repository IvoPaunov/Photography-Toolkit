# Photography-Toolkit
A small collection of tools for serious photographers. (Yet not for pros)


### This is a course project for Windows Applications for Mobile 2015 course @ [Telerik Academy](https://github.com/TelerikAcademy).
- [Requirements](https://github.com/TelerikAcademy/Windows-Applications/blob/master/Course-Project/LOB_APP_REQUIREMENTS.md);
- 

### Application features

* Exposure Calculator
	* Calculates different relations between aperture, shutter speed, ISO with additional role of ND filter to the result values if it is in use
* Minimal shutter speed
	* Calculates the minimum shutter speed for cameras and lenses without image stabilization
	* The result considers the sensor size of the camera, the focal length of the lens and most important – test and adds to the result user’s hand shaking value wising the Accelerometer.
 
* Sunset and sunrise times
	* Automatically detects the user’s location and displays the time of the sunset and the sunrise times
	* The data is requested [http://sunrise-sunset.org/api](from http://sunrise-sunset.org/api) 
	* There is an option to set alarm before subset, sunrise or both

*  Compass
	* Just compass yet, In future it should track the marked objects (like Milky Way)

* Photo Galley
	* A simple photo gallery in order to cover gesture requirements

* Tutorials
	* A simple YouTube search with some predefined tags and keywords and channels

* Login account and Settings
	* Keep settings about different configurations of cameras and lenses of the user
	* If the user is registered these settings are kept in the cloud (Parse.com)

* Navigation
	* Fluid multi devise responsive navigation with the new shiny Windows Universal Platform SplitView controller.

