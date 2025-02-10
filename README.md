BoomWords is a real-time multiplayer word game where you must find words containing a given syllable before the bomb explodes.

## Features
- Client in C# .NET and server in C.
- Online gameplay with friends.
- Supports multiple simultaneous matches using multithreading.
- Player turn management.
- Optimized communication for low latency.


## Technical Challenges
- **Real-time synchronization:** Efficient communication between the C server and the C# client.
- **Online database:** MySQL database hosted in a external server.
- **Concurrency management:** Support for multiple active game rooms simultaneously.
- **Random mechanics:** Fair algorithm for bomb explosions.

## How to Play
1. Join or create a game room.
2. A syllable is assigned at the start of the round.
3. Type a word that contains it before the bomb explodes.
4. If the bomb explodes on your turn, you lose a life.
5. The last player standing wins.

[Watch gameplay](https://www.youtube.com/watch?v=x35CfjYpp5o)


