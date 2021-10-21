# WindowsApps
This c# project consists of two different subprojects; Lottery Simulator and Windows Calculator. 

## Windows Calculator
This project is about developing a calculator with a graphical interface, which handles the four arithmetic methods (+, -, *, /). An example could be that the user takes a chance on 6, 12, 22, 13, 20, 27 and 34, and wants to randomly draw 999999 draws (lottery lines with 7 numbers between (including) 1-35). When that has been completed, the user should see for example, that 1200 times the user has had 5 right, 25 times 6 right and 2 times 7 right. The program also handles incorrect entries from the user through exceptions.

### Requirements specification
- An entered line should only accept unique positive numbers between 1-35.
  - In the lottery line, the position of numbers does not matter.
  - No duplicates may be present among the numbers.
- Number of draws must be an integer, not a negative number.
- You should not be able to start a draw unless both a correct line is filled in and the number of draws is correct

## Lottery Simulator
The project is about creating a simulator for lottery draws, which the program presents how many "wins" there will be that have 5, 6 resp. 7 right after x number (user enters x) draws.
