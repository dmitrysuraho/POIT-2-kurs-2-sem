import javax.servlet.RequestDispatcher;
import javax.servlet.ServletContext;
import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;
import java.io.IOException;
import java.io.PrintWriter;

@WebServlet(name = "Servlet6.1", urlPatterns="/FirstServlet")
public class Servlet61 extends HttpServlet {
    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        PrintWriter pw = response.getWriter();
        pw.println("the first servlet...");
        ServletContext servletContext2 = getServletContext();
        String some = "Data";
        servletContext2.setAttribute("SomeB", some);
        String path = "/SecondServlet";
        ServletContext servletContext = getServletContext();
        RequestDispatcher requestDispatcher = servletContext.getRequestDispatcher(path);
        requestDispatcher.forward(request, response);
    }

    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
//        PrintWriter pw = response.getWriter();
//        pw.println("the first servlet...");
//        String path = "/SecondServlet?data=dmitry";
//        ServletContext servletContext = getServletContext();
//        RequestDispatcher requestDispatcher = servletContext.getRequestDispatcher(path);
//        requestDispatcher.forward(request, response);

       //переадресация
        String path = request.getContextPath() + "/SecondServlet?data=dmitry";
        response.sendRedirect(path);
    }
}
