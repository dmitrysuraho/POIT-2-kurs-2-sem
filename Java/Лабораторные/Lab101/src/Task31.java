import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.FileWriter;
import java.io.IOException;
import java.io.PrintWriter;

@WebServlet(name = "Task3.1", urlPatterns = "/Task3.1")
public class Task31 extends HttpServlet {
    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        String login = request.getParameter("login");
        String pass = request.getParameter("pass");
        PrintWriter pw = response.getWriter();
        if(login.isEmpty() || pass.isEmpty()) {
            pw.println("Check login or pass");
        }
        else {
            FileWriter nFile = new FileWriter("C:\\Users\\Dmitry\\Desktop\\labs\\Java\\Лабораторные\\Lab101\\users.txt",true);
            nFile.write("\nuser " + login + " " + pass);
            nFile.close();
            pw.println("Successful");
        }
    }

    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {

    }
}
