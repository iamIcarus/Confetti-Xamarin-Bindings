![](https://github.com/jinatonic/confetti/blob/master/assets/confetti_with_touch.gif)
![](https://github.com/jinatonic/confetti/blob/master/assets/falling_confetti_top.gif)
![](https://github.com/jinatonic/confetti/blob/master/assets/explosion_confetti.gif)
![](https://github.com/jinatonic/confetti/blob/master/assets/falling_confetti_point.gif)

Confetti - Xamarin Bindings
=================
This is a Xamarin.Android bindings library for the Confetti native Android library.
For full information and issues that are not related to the Bindings please refer to [Confetti Github](https://github.com/jinatonic/confetti)



What is Confetti?
=================

*Confetti (plural) vs confetto (singular)*

[Confetti](https://en.wikipedia.org/wiki/Confetti) is a high-performance, easily-configurable
particle system library that can animate any set of objects through space. You can specify your
starting conditions and physical conditions (e.g. X and Y acceleration, boundaries, etc.),
and let the confetti library take care of the rest.


Simple usage
------------

The only thing you need to get confetti on your screen is a parent view to host the `ConfettiView`
and thus the confetti animation. From this point on, this parent view is referred to as `container`.

Please note that the library uses measurements from `container` to figure out how to best animate
the confetti. If the `container` is not measured when creating the confetti, then nothing will
show up on the screen. A common pitfall is creating confetti inside activity lifecycle as the views
are most likely not measured at those points.

You can generate pre-configured confetti from `CommonConfetti`. You only need to provide it with
the parent `container`, a `ConfettiSource`, and an array of possible colors for the confetti.
The default confetti shapes are circle, triangle, and square.

```c#
CommonConfetti.RainingConfetti(container, new int[] { Color.Black }).Infinite();
```


Example
==================

Demo app has the basic usage of Confetti with 3 simple modes. For more advance usage please refer to the original java project

