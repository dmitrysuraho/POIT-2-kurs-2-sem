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

@WebServlet(name = "Servlet6.2", urlPatterns="/SecondServlet")
public class Servlet62 extends HttpServlet {
    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        PrintWriter pw = response.getWriter();
        pw.println("the second servlet...\n");
        ServletContext servletContext = getServletContext();
        String obj = (String)servletContext.getAttribute("SomeB");
        pw.println(obj);
    }

    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        PrintWriter pw = response.getWriter();
        pw.println("the second servlet...\n");
        String obj = request.getParameter("data");
        pw.println(obj);
//        String path = "/Task6.jsp";
//        ServletContext servletContext2 = getServletContext();
//        RequestDispatcher requestDispatcher = servletContext2.getRequestDispatcher(path);
//        requestDispatcher.forward(request, response);
    }
}
