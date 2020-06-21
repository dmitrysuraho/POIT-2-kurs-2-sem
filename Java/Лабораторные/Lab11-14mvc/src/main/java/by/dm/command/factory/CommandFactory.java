package by.dm.command.factory;

import by.dm.command.Command;
import by.dm.command.LoginPageCommand;
import by.dm.command.RegisterPageCommand;
import by.dm.command.authorithation.LoginCommand;
import by.dm.command.authorithation.RegisterNewUserCommand;
import by.dm.command.authorithation.SingOutCommand;
import by.dm.command.grouppresons.AddNewPersonCommand;
import by.dm.command.grouppresons.WelcomeCommand;

//Создает команды

public class CommandFactory {
    public static Command create(String command) {
        command = command.toUpperCase();
        System.out.println(command);
        CommandType commandEnum = CommandType.valueOf(command);
        Command resultCommand;
        switch (commandEnum) {
            case LOGIN: {
                resultCommand = new LoginCommand();
                break;
            }
            case REGISTER_NEW_USER: {
                resultCommand = new RegisterNewUserCommand();
                break;
            }
            case SIGN_OUT: {
                resultCommand = new SingOutCommand();
                break;
            }
            case ADD_NEW_PERSON:{
                resultCommand = new AddNewPersonCommand();
                break;
            }
            case LOGIN_PAGE:{
                resultCommand = new LoginPageCommand();
                break;
            }
            case WELCOME:{
                resultCommand = new WelcomeCommand();
                break;
            }
            case REGISTRATION_PAGE:{
                resultCommand = new RegisterPageCommand();
                break;
            }

            default: {
                throw new IllegalArgumentException("Invalid command" + commandEnum);
            }
        }
        return resultCommand;
    }
}
