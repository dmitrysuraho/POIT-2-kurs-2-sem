package by.dm.command.grouppresons;

import by.dm.command.Command;
import by.dm.command.CommandResult;
import by.dm.exception.IncorrectDataException;
import by.dm.exception.ServiceException;
import by.dm.model.Person;
import by.dm.service.PersonService;
import by.dm.util.pages.Page;
import static by.dm.command.grouppresons.constant.GroupConstant.*;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.util.List;


public class WelcomeCommand implements Command {
    @Override
    public CommandResult execute(HttpServletRequest request, HttpServletResponse response)
            throws ServiceException, IncorrectDataException {

        PersonService personService = new PersonService();
        List<Person> clients = personService.findAll();
        if (!clients.isEmpty()) {
            request.setAttribute(LISTGROUP, clients);
        }
        return new CommandResult(Page.WELCOME_PAGE.getPage(), false);
    }
}

