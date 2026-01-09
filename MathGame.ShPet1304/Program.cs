// **Global Variables**
Random numbers = new Random();
int leftHandOperand = numbers.Next(1, 101);
int rightHandOperand = numbers.Next(1,101);
int answer;
int newUserAnswer;
int userScore = 0;
int maxRounds = 5;
string? userAnswer;
string result;
bool gameRunning = true;
List<object[]> gameHistory = new List<object[]>();

  

//--Initialize Game--
while (gameRunning)
{
Menu();
}


//--Methods--

void Menu( int choice = default)
{ 
  Console.WriteLine("Choose an option:\n1) Addition Math Questions\n2) Subtraction Math Questions\n3) Multiplication Math Questions\n4) Division Math Questions\n5) Random Operator Math Questions\n6) Game History\n7) Exit");
  
  string? menuSelection = Console.ReadLine();
  
  if (menuSelection != null)
    {
      int.TryParse(menuSelection, out choice);

    switch (choice)
  {
    case 1:
        GameMode("addition");
        break;

    case 2:
        GameMode("subtraction");
       
        break;

    case 3:
       GameMode("multiplication");
       
        break;

    case 4:
      GameMode("division");
       
        break;

    case 5:
      Console.Clear();
         Random option = new Random();
       Console.WriteLine("Random Math Game:");
        for(int i = 0; i < maxRounds; i++){
          int randomOperation = option.Next(1,5);
          switch (randomOperation)
          {
          case 1:
            GameMode("addition");
            break;

          case 2:
            GameMode("subtraction");
            break;

          case 3:
            GameMode("multiplication");
            break;

          case 4:
            GameMode("division");
            break;

          default:
            ReturnToMenu();
            break;
          }
        }
        break;

    case 6:
        GameRecords();
        ReturnToMenu();
        break;

    case 7:
        gameRunning = false;
        Console.WriteLine("Goodbye :)");
        break;

    default:
        Console.WriteLine("Enter a number option");
        ReturnToMenu();
        break;
    
    
  }
    }
}

void GameMode(string mode)
{
  switch(mode){

  case "addition":
        Console.WriteLine("Addition Math Game:");
        for(int i = 0; i < maxRounds; i++){

          leftHandOperand = numbers.Next(1, 101);
          rightHandOperand = numbers.Next(1,101);

          answer = leftHandOperand + rightHandOperand;

          Console.WriteLine( $"{leftHandOperand} + {rightHandOperand} = ??" );

          userAnswer = Console.ReadLine();
          int.TryParse(userAnswer, out newUserAnswer);
          if (newUserAnswer == answer)
          {
            userScore += 1;
            Console.WriteLine($"Correct {leftHandOperand} + {rightHandOperand} = {answer}");
            result = "Win";
          }

          else 
          {Console.WriteLine($"Wrong. The Answer is {answer}");
            result = "Lose";
          }
          

          gameHistory.Add(new object[] { 
            $"{leftHandOperand} + {rightHandOperand}", 
            answer, 
            result });
        }

        Console.WriteLine($"Game Over\nYour Final score is: {userScore}/5");
         ReturnToMenu();
        userScore = 0;
        break;

    case "subtraction":
        Console.WriteLine("Subtraction Math Game:");
        for(int i = 0; i < maxRounds; i++){

          leftHandOperand = numbers.Next(1, 101);
          rightHandOperand = numbers.Next(1,101);

          if (rightHandOperand > leftHandOperand)
          {
            (leftHandOperand, rightHandOperand) = (rightHandOperand, leftHandOperand);
          }
          answer = leftHandOperand - rightHandOperand;
          Console.WriteLine( $"{leftHandOperand} - {rightHandOperand} = ??" );

          userAnswer = Console.ReadLine();
          int.TryParse(userAnswer, out newUserAnswer);

          if (newUserAnswer == answer)
          {
            userScore += 1;
            Console.WriteLine($"Correct {leftHandOperand} - {rightHandOperand} = {answer}");
            result = "Win";
          }

          else 
          {
            Console.WriteLine($"Wrong. The Answer is {answer}");
            result = "Lose";
          }

         
          gameHistory.Add(new object[] { 
            $"{leftHandOperand} - {rightHandOperand}", 
            answer, 
            result });
          }
            Console.WriteLine($"Game Over\nYour Final score is: {userScore}/5");
            userScore = 0;
            ReturnToMenu();
       
        break;

    case "multiplication":
       
        for(int i = 0; i < maxRounds; i++)
        {
          int multiplyLeftHandOperands = numbers.Next(1, 101);
          int multiplyRightHandOperands = numbers.Next(1, 101);
          answer = multiplyLeftHandOperands * multiplyRightHandOperands;
          Console.WriteLine( $"{multiplyLeftHandOperands} * {multiplyRightHandOperands} = ??" );
          userAnswer = Console.ReadLine();
          int.TryParse(userAnswer, out newUserAnswer);
          if (newUserAnswer == answer)
          {
            userScore += 1;
            Console.WriteLine($"Correct {multiplyLeftHandOperands} * {multiplyRightHandOperands} = {answer}");
            result = "Win";
          }

          else {
            Console.WriteLine($"Wrong. The Answer is {answer}");
            result = "Lose";
          }
          gameHistory.Add(new object[] { 
            $"{multiplyLeftHandOperands} * {multiplyRightHandOperands}", 
            answer, 
            result });
          
         
        }
        
    
        Console.WriteLine($"Game Over\nYour Final score is: {userScore}/5");
        ReturnToMenu();
        userScore = 0;
        break;

    case "division":
      
        for(int i = 0; i < maxRounds; i++)
      {
        int dividend;
        int divisor; 
    
    
        do{
          dividend = numbers.Next(1, 101);
          divisor = numbers.Next(1, 101);
    
        } while(dividend % divisor != 0 || dividend < divisor);
    
        answer = dividend / divisor;
    
        Console.WriteLine( $"{dividend} / {divisor} = ??" );
        userAnswer = Console.ReadLine();
        int.TryParse(userAnswer, out newUserAnswer);
        if (newUserAnswer == answer)
        {
          userScore += 1;
          Console.WriteLine($"Correct {dividend} / {divisor} = {answer}");
          result = "Win";
        }

        else {
          Console.WriteLine($"Wrong. The Answer is {answer}");
          result = "Lose";
        }
          
        gameHistory.Add(new object[] { 
            $"{dividend} / {divisor}", 
            answer, 
            result });
        
        }
          

        Console.WriteLine($"Game Over\nYour Final score is: {userScore}/5");
        ReturnToMenu();
        userScore = 0;
        break;
  }
        }
  

void ReturnToMenu()
{ 
  Console.WriteLine("Press Enter to return to the Main Menu.");
  Console.ReadLine();
  Console.Clear();
  Console.Write("\x1b[3J");
  Console.Clear();
  Menu();
}




void GameRecords()
{ 
  Console.WriteLine("\n\tHistory Table:\n");
  Console.WriteLine("Problem\t\tAnswer\t\tResult");
  foreach (object[] game in gameHistory)
{
    Console.WriteLine($"{game[0]}\t\t{game[1]}\t\t{game[2]}");
}
Console.WriteLine();

}
