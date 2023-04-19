# Autimented Reality

Unity SDK to enable developers detect and act upon sensory overload in autistic individuals during XR experiences.


Winner of the harvrd dreamhack 2023 at Harvard University.
Developed by Darius Huang, Leon Kipkoech, Rukhshan Haroon, Alex K. Chen at Harvard University 2023 for dreamhack by harvrd xr club. 

![final](https://user-images.githubusercontent.com/39020723/232945519-4b3edaa5-f6bd-4d45-9568-b5916cc27da4.jpg)
![team](https://user-images.githubusercontent.com/39020723/232943424-b093b3d5-95d2-4af2-a207-1e448399221a.jpg)

## Description
The project is focused on developing a software development kit (SDK) for Unity developers to create augmented reality (AR) and Virtual Reality (VR) experiences that are specifically designed to be usable and accessible for individuals with autism. 

## Problem Satement
Autism is a neurodevelopmental disorder that is caused by a mix of genetic and environmental factors, and it is a global health problem affecting 1 in 68 children. Individuals with autism often experience impaired verbal communication, difficulties in recognizing facial expressions, and problems with eye contact. Additionally, they may experience sensory overload due to visual stimulus or audio noise. If sensory overload is not taken into account, XR experiences may not be fully accessible to individuals with Autism.

## Solution
To address these challenges, the team created an SDK that tracks the rate of change of eye-gaze movement to detect sensory overload in sight. If sensory overload is detected, the augmented field of view is edited on the fly to make the experience more comfortable for the individual. Two XR experiences were created to showcase the use and implementation of the SDK. 

![teamopr2](https://user-images.githubusercontent.com/39020723/232949102-6ab6bd35-4adf-46e4-8772-e67adfe800e6.jpg)

### Use Case 1

The first experience is an educational app that simulates the solar system in AR. The teacher talks about one planet (target) at a time, and the target is fixed while the remaining planets orbit around the user. If sensory overload is detected, the other planets stop moving, allowing the user to focus on the target planet.

### Use Case 2
The second XR experience is set in a museum scenario, where two characters move in a motion similar to dancing. If sensory overload is experienced, the animation stops, and an image is centered between the characters. The SDK leverages the Magic Leap eye-tracking API to track eye movement and detect sensory overload in real-time. By using this SDK, Unity developers can create more inclusive and accessible XR experiences for individuals with autism.

## Challenges
One of the main challenges faced by the project team was translating BCI data into human-understandable data by correlating it with emotional states. This involved finding ways to classify EEG signals and extract meaningful insights that could inform the design of AR experiences for individuals with autism. Developing these algorithms required expertise in signal processing, machine learning, and data visualization.

Another challenge was integrating the BCI data with the Unity SDK to create personalized AR experiences on the fly. This involved using the magic leap eye tracking API to capture eye gaze data and EEG measurements in real-time and updating the AR experience based on the user's emotional state. This required knowledge of software engineering, Unity development, and AR design.

In addition, the project team faced technical difficulties when working with the magic leap device, which none of the team members had prior experience with. Specifically, the team encountered issues with the magic leap hub application simulator, which prevented them from using the "hot reload" feature to quickly test and iterate on changes. As a result, the team had to build and run the application every time they made a change, which slowed down the development process and was frustrating for the team especially with the time constraint. This required problem-solving skills, resourcefulness, and patience to overcome.

## Future of work
The team plans to leverage brain-computer interface (BCI) data to provide deeper insights into sensory overload. Specifically, EEG measurements can be used to classify the user's emotional state, which can then be used to alter the AR experience on the fly to provide a more comfortable experience. This approach has immense potential for impact in the field of affective computing, as it prioritizes accessibility-first design principles. For example, this technology can be used in autism therapy, such as with the Stanford SuperPower Glass, to create more personalized and effective therapies that are tailored to the needs and preferences of each individual. By prioritizing accessibility-first design, the project team aims to create more inclusive and meaningful AR experiences for all individuals, regardless of their abilities or sensory sensitivities.


## Tech Stack 
Frameworks: `Unity`, `MRTK`, `XR Interaction Toolkits`, `Magic Leap Mesh` and `Eye Tracking API`
Hardware: `Magic Leap 2`

## Demo: 

### _demo scene 1, education, Solar/Planetary System_

[![uses of autimented reality SDK](http://img.youtube.com/vi/MH-ThvZUHNE/0.jpg)](http://www.youtube.com/watch?v=MH-ThvZUHNE "uses of autimented reality SDK")

### _demo scene 2, art/museum_

[![Use case two: art/museum](http://img.youtube.com/vi/9Rk4QGgXhDA/0.jpg)](http://www.youtube.com/watch?v=9Rk4QGgXhDA "Use case two: art/museum")
