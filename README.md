# Android Startup Performance
Xamarin management has identified Android startup performance as our top issue. 

# Goal
What, exactly constitutes "Startup performance"? It could mean different things to different people. For example, [this customer][1] blogs about (1) time to launch a minimal app (e.g. "Hello World") and (2) an app with a bit of XAML. The first would target mono/android stack while the latter would target XAML performance. Both could be targeted, but which first? 

To fix the right issue, the top issue, and to properly measure our progress we need to know the specific feedback management is looking at. Bugs? Twitter? Blog posts? Sales and support? Telemetry? 

Is this the top priority? And if so, which scenario, exactly, are we optimizing? This is step 0.
# Blog
_January_

Just to get going, let's assume we're minimizing hot launch times of our template projects. That's the default experience we expose so we should track it regardless. We should also compare it against our competitors default startup times.

Our scenarios are: 
* The Xamarin Forms Android template project
* The Xamarin Android template project
* A native Java Android project

[This customer][1] simply used `Java.Lang.JavaSystem.CurrentTimeMillis()` to time the difference between `onCreate` and `onResume`. That was enough to kick off this project, so we might as well start there! Because that will not capture the entire startup stack we, just for fun, took slow motion video capture of [Xamarin.Android][XAStartUp] and [Xamarin.Forms][XFStartUp] starting up. With those numbers we can compare:
* WC: Wall Clock
* App: `onResume` - `onCreate`, application inc XF
* Mono/XA: WC - C#, roughly mono + XA

|Plat|WC|%|App|%|Mono+XA|%
|---:|---:|---:|---:|---:|---:|---:|
|XF|2150ms| |875ms| 40%|1275ms| 60%|
|XA|1200ms| |113ms| 10%|1087ms| 90%|
|XF vs XA|+950ms| +80%|+762ms| +8x|+188| -20%|

So, at first glance, XF template takes almost %60-80 longer to load as a plain XA project.

After we get crawling, Marek Habersack of the Android team has suggested using [SimplePerf][SimplePerf] profiler. 

# Stack and Scenarios
Xamarin startup time can be roughly broken down into the following layers which can be roughly measured with the following apps.
|Layer|App|
|---|---|
|XAML|XF Template|
|XF|XF Template w/o XAML|
|XA|XA Template|
|Mono|"Hello World" Console App|

A Android Studio "Hello World" app can provide a baseline.

# Build Considerations
A list of the build switches that affect performance.
* `release`: Use release builds
* `linker`: Use full linking
* `XAML compiler`: Precompile the XAML
* `aot`: ?

# Resources
* [SimplePerf][SimplePerf]: A tool which can help measuring native performance with very little overhead.

# Notes
In reverse chronological order.
## Now
* Rolled up results into README.
* Captured slow motion video of [XFStartUp][XFStartUp] and [XAStartUp][XAStartup] which shows, roughly, the mono startup time.
* Add Xamarin Forms `XFStartUp` app and Xamarin Android `XAStartUp` app from the template projects modified slightly to display the duration between `onCreate` and `onResume`.
* Create repository and this README.
## January


[1]: https://programistologia.pl/2019/01/03/en-what-bothers-xamarin-developers-part-3/
[SimplePerf]: https://android.googlesource.com/platform/system/extras/+/master/simpleperf/doc/README.md
[XAStartUp]: https://m.youtube.com/watch?v=G9ylTGtsy5s
[XFStartUp]: https://www.youtube.com/watch?v=cKz8KDs1NAA