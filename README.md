# HBWAbilitySwitcher

<p align="center">
  <img src="images/demo.gif" alt="animated" />
</p>

<!-- Shield -->

[![Contributors][contributors-shield]][contributors-url]
[![Download][download-shield]][download-url]
[![Forks][forks-shield]][forks-url]
[![Stargazers][stars-shield]][stars-url]
[![Issues][issues-shield]][issues-url]
[![MIT License][license-shield]][license-url]

# About The Mod

Quick in game ability switcher for Haste for controller (As long as your controller is recognized as XInput, it should work; Keyboard might be planned )

Use your controller D-PAD to switch to the desired unlocked ability (That's right, the mod does not unlock the ability for you, switch happen if the ability is already unlocked in your game)

Built for the game version 1.2.d (meaning it might not work right away with an update)

(up = BoardBoost, left = Fly, right = Grapple, down = Slomo)

# Usage

The game doesn't have (yet!) an official modding support, we use [BepInEx](https://github.com/BepInEx/BepInEx) as the game patcher as an alternative:

- Follow the official installation guide [here](https://docs.bepinex.dev/articles/user_guide/installation/index.html) and use this prelease when downloading [v6.0.0-pre2](https://github.com/BepInEx/BepInEx/releases/tag/v6.0.0-pre.2) (The file you want is _BepInEx-Unity.Mono-win-x64-6.0.0-pre.2.zip_)
- Download the [latest release](https://github.com/Fcornaire/HBWAbilitySwitcher/releases/latest) and extract to your {game_path}/BepInEx/plugins/HBWAbilitySwitcher
- Launch the game and check if the mod is working as intended (use your controller D-PAD)

# Building

- Clone thi repository
- Set the environment variable **HBWPath** pointing to your own game install (something like _..\Steam\steamapps\common\Haste_)
- Use your favorite IDE (Rider and other not tested) to build the project
- Upon building,the compiled plugin should be copied to directly to your game path (not sure if copy work in other IDE)

# Social

Bsky : [Dshad66](https://bsky.app/profile/dshad66.bsky.social)

Twitter : DShad - [@DShad66](https://twitter.com/DShad66)

Discord : dshad (was DShad#4670)

<!-- MARKDOWN LINKS & IMAGES -->
<!-- https://www.markdownguide.org/basic-syntax/#reference-style-links -->

[contributors-shield]: https://img.shields.io/github/contributors/Fcornaire/HBWAbilitySwitcher.svg?style=for-the-badge
[contributors-url]: https://github.com/Fcornaire/HBWAbilitySwitcher/graphs/contributors
[forks-shield]: https://img.shields.io/github/forks/Fcornaire/HBWAbilitySwitcher.svg?style=for-the-badge
[forks-url]: https://github.com/Fcornaire/HBWAbilitySwitcher/network/members
[stars-shield]: https://img.shields.io/github/stars/Fcornaire/HBWAbilitySwitcher.svg?style=for-the-badge
[stars-url]: https://github.com/Fcornaire/HBWAbilitySwitcher/stargazers
[issues-shield]: https://img.shields.io/github/issues/Fcornaire/HBWAbilitySwitcher.svg?style=for-the-badge
[issues-url]: https://github.com/Fcornaire/HBWAbilitySwitcher/issues
[license-shield]: https://img.shields.io/github/license/Fcornaire/HBWAbilitySwitcher.svg?style=for-the-badge
[download-shield]: https://img.shields.io/github/downloads/Fcornaire/HBWAbilitySwitcher/total?style=for-the-badge
[download-url]: https://github.com/Fcornaire/HBWAbilitySwitcher/releases
[license-url]: https://github.com/Fcornaire/HBWAbilitySwitcher/blob/master/LICENSE.txt
