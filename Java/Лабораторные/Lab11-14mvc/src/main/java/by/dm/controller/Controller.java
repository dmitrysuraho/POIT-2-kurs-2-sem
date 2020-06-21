package by.dm.controller;

import by.dm.command.Command;
import by.dm.command.CommandResult;
import by.dm.command.factory.CommandFactory;
import by.dm.connection.ConnectionPool;
import by.dm.exception.IncorrectDataException;
import by.dm.exception.ServiceException;
import by.dm.util.pages.Page;

import javax.servlet.RequestDispatcher;
import javax.servlet.ServletContext;
import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;

public class Controller extends HttpServlet {

    private static final String COMMAND = "command";
    private static final String ERROR_MESSAGE = "error_message";


    @Override
    public void destroy() {
        ConnectionPool.getInstance().destroy();
    }

    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        processRequest(request, response);
    }

    @Override
    public void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        processRequest(request, response);
    }

    private void processRequest(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {

        String command = request.getParameter(COMMAND);
        Command action = CommandFactory.create(command);

        CommandResult commandResult;
        try {
            commandResult = action.execute(request, response);
        } catch (ServiceException | IncorrectDataException e) {
            request.setAttribute(ERROR_MESSAGE, e.getMessage());
            commandResult = new CommandResult(Page.ERROR_PAGE.getPage(), false);
        }

        String page = commandResult.getPage();
        if (commandResult.isRedirect()) {
            sendRedirect(response, page);
        } else {
            dispatch(request, response, page);
        }
    }


    private void dispatch(HttpServletRequest request, HttpServletResponse response, String page) throws ServletException, IOException {
        ServletContext servletContext = getServletContext();
        RequestDispatcher requestDispatcher = servletContext.getRequestDispatcher(page);
        requestDispatcher.forward(request, response);
    }

    private void sendRedirect(HttpServletResponse response, String page) throws IOException {
        response.sendRedirect(page);
    }
}
