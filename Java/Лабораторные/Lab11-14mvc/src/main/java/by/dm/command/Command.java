package by.dm.command;

import by.dm.exception.IncorrectDataException;
import by.dm.exception.ServiceException;
import javax.servlet.ServletException;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;

public interface Command {
    CommandResult execute(HttpServletRequest request, HttpServletResponse response) throws  ServiceException, IncorrectDataException, ServletException, IOException;
}
