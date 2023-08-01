<a name="readme-top"></a>

<!-- PROJECT SHIELDS -->
[![Contributors][contributors-shield]][contributors-url]
[![Forks][forks-shield]][forks-url]
[![Stargazers][stars-shield]][stars-url]
[![Issues][issues-shield]][issues-url]
[![MIT License][license-shield]][license-url]
[![LinkedIn][linkedin-shield]][linkedin-url]


<!-- PROJECT LOGO -->
<br />
<div align="center">
  <a href="https://github.com/junseo-yang/castle-defense">
    <img src="CastleDefense/CastleDefense/Castle.ico" alt="Logo" width="80" height="80">
  </a>

  <h3 align="center">castle-defense</h3>

  <p align="center">
    Protect your castle from your enemies who wants to destroy it!
    <br>
    <a href="https://github.com/junseo-yang/castle-defense"><strong>Explore the docs »</strong></a>
    <br />
    <br />
    <a href="https://github.com/junseo-yang/castle-defense">View Demo</a>
    ·
    <a href="https://github.com/junseo-yang/castle-defense/issues">Report Bug</a>
    ·
    <a href="https://github.com/junseo-yang/castle-defense/issues">Request Feature</a>
  </p>
</div>



<!-- TABLE OF CONTENTS -->
<details>
  <summary>Table of Contents</summary>
  <ol>
    <li>
      <a href="#about-the-project">About The Project</a>
      <ul>
        <li><a href="#built-with">Built With</a></li>
      </ul>
    </li>
    <li>
      <a href="#getting-started">Getting Started</a>
      <ul>
        <li><a href="#prerequisites">Prerequisites</a></li>
        <li><a href="#installation">Installation</a></li>
      </ul>
    </li>
    <li><a href="#Description">Description</a></li>
    <li><a href="#roadmap">Roadmap</a></li>
    <li><a href="#contributing">Contributing</a></li>
    <li><a href="#license">License</a></li>
    <li><a href="#contact">Contact</a></li>
  </ol>
</details>



<!-- ABOUT THE PROJECT -->
## About The Project

**castle-defense** is an game that you can play to defence a castle with your archer from the invasion of enemies.

[![Gif Game Control][gif-game-control]](https://github.com/junseo-yang/castle-defense)

<p align="right">(<a href="#readme-top">back to top</a>)</p>



### Built With
* [![C#][C#]][C#-url]
* [![.NET][.NET]][.NET-url]
* [![MonoGame][MonoGame]][MonoGame-url]

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- GETTING STARTED -->
## Getting Started

This is an example of how you may give instructions on setting up your project locally.
To get a local copy up and running follow these simple example steps.

### Prerequisites

1. Windows
2. .NET core 3.1 or above

### Installation
#### One click installer
1. Clone the repo
    ```sh
    git clone https://github.com/junseo-yang/castle-defense.git
    ```
2. Change Directory to `OneClickInstaller`
    ```sh
    cd OneClickInstaller
    ```
3. Execute `setup.exe` to get dependencies
    ```sh
    setup.exe
    ```
4. Run the Application
    ```sh
    CastleDefense.exe
    ```

#### Run Locally
1. Clone the repo
    ```sh
    git clone https://github.com/junseo-yang/castle-defense.git
    ```
2. Open the project with Visual Studio
    ```sh
    cd CastleDefense
    open CastleDefense.sln
    ```
3. Run the Application

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- USAGE EXAMPLES -->
## Description
### Purpose
You need to defense a Castle with your archer from the invasion of enemies.

### Starting Game
[![Screenshot Start][screenshot-start]](https://github.com/junseo-yang/castle-defense)

In the beginning of the game, you need to enter a unique player name that you are going to use for the high score record.

### Play Sound and Music
After you enter a player name, the background music *Eldon - Pink cheeks* will be played and continuously repeated. Each time you shoot an arrow or use a bomb, the sound effect of arrow shooting sound and bomb explosion sound will be played.

### Screens
In a game you have 5 screens, Start screen with menu, Game screen, Help, High Score, and Credit. You can select menu by using keyboard arrow keys and hit enter. In the help scene, you can see the description how to play the game. In the Credit Scene

[![Screens GIF][gif-screen]](https://github.com/junseo-yang/castle-defense)


### Game Control
While you are playing game, you can control your archer to aim and shoot arrows by mouse and use bombs by keyboard button B. You can pause while you are playing game with keyboard button P. You can go back to the start screen by `ESC` key from Game, Help, High Score, Credit Screen. You can quit the game by select Quit menu and hit enter.

[![Gif Game Control][gif-game-control]](https://github.com/junseo-yang/castle-defense)

### Level and Score System
Your level start with level 1. Each time you kill an enemy by shooting an arrow, your score increases by one. If you collect **20** points at each level, you can clear a level and move on to the next level.

### Save Game & Load Game
Player name, level, and score are saved automatically to the file `CastleDefenseSave.txt`. You will start with Level 1 and Score 0, and you can check on the high score screen if you are the first player. You can stop playing game anytime you want with press ESC. But, if you want to keep playing with your saved level and score, you need to hit enter on the load game. If you hit the enter on the start new game or lose a game and start a new game, then the saved level and score will be initialized and overridden. If you lost the previous game, you can’t load game and a new game will start.

[![Gif Load game][gif-load-game]](https://github.com/junseo-yang/castle-defense)


### High Score Screen
You can see the top 5 high scores in the High Score Screen. If game save file is contaminated, it will be deleted and exit the game.

[![Screenshot High Score][screenshot-high-score]](https://github.com/junseo-yang/castle-defense)

### Credit Screen
You can see the game creator of castle defense.

[![Screenshot Credit][screenshot-credit]](https://github.com/junseo-yang/castle-defense)

### Archer & Arrow
Archer’s shooting speed and arrow speed will be increased according to the level.

### Enemies
In each level, enemies are generated randomly according to the level you are in. In level 1, an enemy ‘red bat’ will come out. In level 2, an enemy ‘Samurai’ will be added. In level 3, an enemy ‘Normal Zombie’ will be added. In level 4, an enemy ‘Mad Zombie’ will be added. Enemies moving speed will be increased randomly according to the level you are in.
| Red Bat                                                    | Samurai                                                    | Normal Zombie                                                          | Mad Zombie                                                       |
| ---------------------------------------------------------- | ---------------------------------------------------------- | ---------------------------------------------------------------------- | ---------------------------------------------------------------- |
| [![Red Bat][Red-Bat]](https://github.com/junseo-yang/castle-defense) | [![Samurai][Samurai]](https://github.com/junseo-yang/castle-defense) | [![Normal Zombie][Normal-Zombie]](https://github.com/junseo-yang/castle-defense) | [![Mad Zombie][Mad-Zombie]](https://github.com/junseo-yang/castle-defense) |


### Special Feature – Bomb
The number of Bomb you can use depends on the level. In the level 1~4, you can’t use bomb. If you clear 5 levels or more levels, you can get certain chance of using bomb so that you can clear the enemies on the field, but the score will not be increased.

[![Gif Bomb][gif-bomb]](https://github.com/junseo-yang/castle-defense)

### Class Diagram
Open [GameDesignDocument](GameDesignDocument.pdf)


<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- ROADMAP -->
## Roadmap

- [x] Implement Starting Game feature
- [x] Implement Play Sound and Music feature
- [x] Implement Screens feature
- [x] Implement Game Control feature
- [x] Implement Save Game & Load Game feature
- [x] Implement High Score Screen feature
- [x] Implement Credit Screen feature
- [x] Implement Archer & Arrow feature
- [x] Implement Enemies feature
- [x] Implement Special Feature – Bomb feature

See the [open issues](https://github.com/junseo-yang/ootd/issues) for a full list of proposed features (and known issues).

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- CONTRIBUTING -->
## Contributing

Contributions are what make the open source community such an amazing place to learn, inspire, and create. Any contributions you make are **greatly appreciated**.

If you have a suggestion that would make this better, please fork the repo and create a pull request. You can also simply open an issue with the tag "enhancement".
Don't forget to give the project a star! Thanks again!

1. Fork the Project
2. Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3. Commit your Changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the Branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- LICENSE -->
## License

Distributed under the MIT License. See `LICENSE.txt` for more information.

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- CONTACT -->
## Contact

**Junseo Yang**
- :briefcase: LinkedIn: https://linkedin.com/in/junseo-yang
- :school_satchel: Website: https://junseo-yang.github.io
- :mailbox: jsy724724@gmail.com

Project Link: [https://github.com/junseo-yang/castle-defense](https://github.com/junseo-yang/castle-defense)

<p align="right">(<a href="#readme-top">back to top</a>)</p>


<!-- MARKDOWN LINKS & IMAGES -->
<!-- https://www.markdownguide.org/basic-syntax/#reference-style-links -->
[contributors-shield]: https://img.shields.io/github/contributors/junseo-yang/castle-defense.svg?style=for-the-badge
[contributors-url]: https://github.com/junseo-yang/castle-defense/graphs/contributors
[forks-shield]: https://img.shields.io/github/forks/junseo-yang/castle-defense.svg?style=for-the-badge
[forks-url]: https://github.com/junseo-yang/castle-defense/network/members
[stars-shield]: https://img.shields.io/github/stars/junseo-yang/castle-defense.svg?style=for-the-badge
[stars-url]: https://github.com/junseo-yang/castle-defense/stargazers
[issues-shield]: https://img.shields.io/github/issues/junseo-yang/castle-defense.svg?style=for-the-badge
[issues-url]: https://github.com/junseo-yang/castle-defense/issues
[license-shield]: https://img.shields.io/github/license/junseo-yang/castle-defense.svg?style=for-the-badge
[license-url]: https://github.com/junseo-yang/castle-defense/blob/main/LICENSE.txt
[linkedin-shield]: https://img.shields.io/badge/-LinkedIn-black.svg?style=for-the-badge&logo=linkedin&colorB=555
[linkedin-url]: https://linkedin.com/in/junseo-yang
[C#]: https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white
[C#-url]: https://dotnet.microsoft.com/en-us/languages/csharp
[.NET]: https://img.shields.io/badge/.NET-512BD4?logo=dotnet&logoColor=fff&style=for-the-badge
[.NET-url]: https://dotnet.microsoft.com/en-us/
[MonoGame]: https://img.shields.io/badge/MonoGame-E73C00?logo=monogame&logoColor=fff&style=for-the-badge
[MonoGame-url]: https://www.monogame.net/
[screenshot-start]: assets/images/screenshots/screenshot-start.png
[gif-game-control]: assets/gifs/game-control.gif
[gif-screen]: assets/gifs/screens.gif
[gif-load-game]: assets/gifs/load-game.gif
[screenshot-high-score]: assets/images/screenshots/screenshot-high-score.png
[screenshot-credit]: assets/images/screenshots/screenshot-credit.png
[gif-bomb]: assets/gifs/bomb.gif
[Red-Bat]: assets/images/enemies/Red-Bat.png
[Samurai]: assets/images/enemies/Samurai.png
[Normal-Zombie]: assets/images/enemies/Normal-Zombie.png
[Mad-Zombie]: assets/images/enemies/Mad-Zombie.png
