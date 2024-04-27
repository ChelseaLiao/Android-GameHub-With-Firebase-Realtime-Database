# Get Start
<b>Video of GameHub and Pattern Capture</b> https://www.youtube.com/watch?v=XDOK8yR51VM
<br><b>Video of Word Master</b> https://www.youtube.com/watch?v=w3MJwl9eJAA
Unity Version: 2021.3.6f1
1. Open the scene and run <b>Assets/Scenes/Start.unity</b>
2. Start with Sign Up
3. Get access any games from the home page
4. For Sign In please check the description unter Functionality 
# GameHub
This game platform provides you two games free to play, with sign up, sign in and sign out
functions.
## Functionality
### Sign In 
with user id and password (TODO: password replication should be implemented), including 2 input fields, one sign in button and one button to the start page. If the sign in
succeeds, user gets into the home page. 
### Sign Up 
with user name and password (TODO: there should be a password validation to be implemented and registration with email should be better), including 2 input fields, one
sign up button and one button to the start page. If the sign up succeeds, user gets into the home page. Home Page with user id and name shown in the upper right corner of the page where
player gets his/her id use to sign in. 
### Sign out 
In the lower left corner of the page you can find the sign out button, you can go back to the start page by clicking it. 
### Play the games
Currently there are two 2D games as demos in this platform.
# 1. Word Master
## About the Game
It's time to test your vocabulary and luck! It's a game of guessing five-letter words based on clues, with no time limit or level setting, meaning there's no end to the game!
## Gameplay
In each round you will be given randomized questions and you have 6 attempts. You can only enter one letter of the alphabet in each input box separately, invalid character inputs will not be displayed. Your answer can only be a valid English word of 5 letters and you will not lose an attempt if it is the wrong input length or an invalid English word. When you make 6 wrong guesses you lose the game, when you guess the word correctly within 6 attempts you win the game, and you can only choose to do the next guessing in both cases!
## Game Design based on NetSpell
### Word & clue selection 
All words and their clues are stored into a real time database of Firebase. The system selects one of them randomly from the database when each round starts.
### Input validation 
The validation is divided into 2 steps, letter validation and word validation
<br><b>1. Letter validation</b> The system first calibrates the player's character inputs in each input box, only English letters will be displayed and other characters will be removed automatically. 
<br<b>2. Word validation</b> After the player clicks the submit button, the system will perform word validation. It will first determine if the word length is 5 letters and if it is a valid English word. If the player's answer is a valid 5-letter English word, the system will check the answer using an English dictionary, here I used a plugin NetSpell.
### Input feedback
After player submits an answer, feedback is displayed below the input fields and lasts 2 seconds
<br<b>1. Green text for correct answer</b> If the player guesses the answer correctly, the green text tells the player that the game is won
<br><b>2. Red text for 3 different types of wrong input</b> Player receives 3 different feedback as 3 different wrong input. 
a. wrong length: input less than 5 letters
b. invalid English: word input is an invalid English word
c. game lose: player doesn’t guess the correct word within 6 attempts
<br><b>3. Feedback for correct and wrong letters</b> After the player submits the answer, the system marks the location of the correct and wrong letter input fields by highlighting them with green and red frames, respectively. The highlights disappear after two seconds.
### UIs
<br><b> 5 input fields</b> The game only provides 5 input fields to avoid answer with more than 5 letters. Each field only accept only one English letter.  
<br><b>Number of remaining attempt</b> Player can see the remaining attempts on the upper left corner, if the submitted answer is a 5-letter valid English word but doesn’t match the correct answer, the attempt number decreases by 1.
<br><b> Submit & next round buttons</b> When player is guessing, there is a submit button under the input fields. After this round end (player won or lost), the submit button is replaced by a button for starting the next round, to avoid a duplicate correct guess or a retry after game lose. 
### Game states 
The game inclues 4 states to process different methods, game data and UIs
<br><b> Attempt</b> The state during player is guessing the answer, before game win or game lose
<br><b> Win</b> Player guesses the correct answer within 6 attempts
<br><b> Lose</b> The attempt number is 0
<br><b> Restart</b> Once player clicks the next round button, data and UIs should be reset, and
the state switches to “Attempt”.
# Firebase Realtime Database 
https://console.firebase.google.com/project/wordle-like/database/wordle-like-default-rtdb/data
The database includes two data references for user data and game data.
## User
User name and password are stored unter user id automatically assigned once register. In addition, the new branch using to save data from a game will be created once player's game data generated.
## Word
To store questions and answers for Word Master 
