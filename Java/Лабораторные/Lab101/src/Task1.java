import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;
import java.io.PrintWriter;
import java.util.Date;
import java.util.Enumeration;

@WebServlet(name = "Task1", urlPatterns = "/Task1")
public class Task1 extends HttpServlet {
    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {

    }

    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        PrintWriter out= response.getWriter();
        out.println("Привет"); // ???
        out.println("time: " + new Date());
        out.println("method " + request.getMethod());
        out.println("URL "+ request.getRequestURL());
        out.println("protocol "+ request.getProtocol());
        out.println("IP"
                + request.getRemoteAddr());
        out.println("Client name " + request.getRemoteHost() + " "
                + request.getRemoteUser());
        out.println("port " + request.getRemotePort());
        out.println("string request " + request.getQueryString());
        out.println("server name and port " + request.getServerName() +
                " " + request.getServerPort());
        out.println("path " + request.getContextPath());
        out.println( request.getScheme());

        Enumeration< String > e = request.getHeaderNames();
        while (e.hasMoreElements()) {
            String name = e.nextElement();
            String value = request.getHeader(name);
            out.println(name + " = " + value);
        }
    }
}
