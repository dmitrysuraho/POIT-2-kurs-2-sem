import javax.servlet.RequestDispatcher;
import javax.servlet.ServletContext;
import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.awt.print.Printable;
import java.io.IOException;
import java.io.PrintWriter;

@WebServlet(name = "Servlet7.1", urlPatterns = "/Servlet7.1")
public class Servlet71 extends HttpServlet {
    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {

    }

    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        ServletContext servletContext = getServletContext();
        String some = "Some Data!!";
        servletContext.setAttribute("data", some);
        String data = (String)servletContext.getAttribute("NewData");
        if(data == null) {
            String path = "/Servlet7.2?data=someData";
            RequestDispatcher requestDispatcher = servletContext.getRequestDispatcher(path);
            requestDispatcher.forward(request, response);
        }
        else {
            PrintWriter pw = response.getWriter();
            pw.println("Get Data: " + data);
        }


    }
}
