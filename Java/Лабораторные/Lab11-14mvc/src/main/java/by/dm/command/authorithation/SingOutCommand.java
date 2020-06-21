package by.dm.command.authorithation;

import by.dm.command.Command;
import by.dm.command.CommandResult;
import by.dm.command.session.SessionAttribute;
import by.dm.exception.IncorrectDataException;
import by.dm.exception.ServiceException;
import by.dm.util.pages.Page;
import org.apache.log4j.Logger;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

public class SingOutCommand implements Command {

    private static final Logger LOGGER = Logger.getLogger(SingOutCommand.class.getName());

    @Override
    public CommandResult execute(HttpServletRequest request, HttpServletResponse response) throws ServiceException, IncorrectDataException {
            HttpSession session = request.getSession();
            String username  = (String)session.getAttribute(SessionAttribute.NAME);
            LOGGER.info("user was above: name:" + username);
            session.removeAttribute(SessionAttribute.NAME);
            return new CommandResult(Page.LOGIN_PAGE.getPage(), false);
        }
}
