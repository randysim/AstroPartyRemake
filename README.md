# AstroPartyRemake

a remake of the classic local party game astroparty with failed multiplayer

# Things to Improve

this was like my second unity project so all the code was horrible.

# Create an AudioManager

One for example is playing audio. instead of playing audio in each game object, create an audio manager for global audio because

when a game object is destroyed, it can't play audio anymore. 

# Make Script Files do what they say

In addition, stop putting random stuff in script files. If something needs a script file make it.

You literally put player awake logic on a health class.

# Not everything has to be a monobehavior.

surprise surprise. you can actually put non-monobehavior classes on your gameobject. some stuff like GameManager doesn't have to be a monobehavior.

# Find a better way of identifying players

the way you identify players is actually horrible. you basically gave each player prefab instance a manual name and then onawake add that name to the GameManager. maybe try having a 

PlayerIdentity script instead.

# Multiplayer

the multiplayer was way too confusing to do given the current state. Im pretty sure the way these Multiplayer Libraries work is create a reference of the remote player

game object onto the client. make sure that it is compatible next time.

# Learning Tips

When trying to learn how to make multiplayer, instead of making some random game and adding multiplayer ontop of it, you should have started with

the lobbyManager and the multiplayer, and the game second, because you don't know how to write a game that is compatible for multiplayer

# .gitignore

make sure to add a gitignore on all the imported assets you used
