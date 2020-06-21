import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.Cookie;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.FileReader;
import java.io.IOException;
import java.util.ArrayList;
import java.util.Date;
import java.util.Scanner;

@WebServlet(name = "Task3Main", urlPatterns = "/Task3Main")
public class Task3Main extends HttpServlet {
    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {

    }

    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
//        Cookie[] cookies = request.getCookies();
//        FileReader fr= new FileReader("C:\\Users\\Dmitry\\Desktop\\labs\\Java\\Лабораторные\\Lab101\\users.txt");
//        Scanner scan = new Scanner(fr);
//        ArrayList<String> users = new ArrayList();
//        while (scan.hasNextLine()) {
//            users.add(scan.nextLine());
//        }
//        fr.close();
//        Boolean flag = false;
//        for (String str: users) {
//            String[] arr = new String[3];
//            arr = str.split(" ");
//            if(cookies !=null) {
//                for(Cookie c: cookies) {
//                    if(arr[1].equals(c.getName())) {
//                        flag = true;
//                        break;
//                    }
//                }
//            }
//        }
//        if(flag) {
//            String path = request.getContextPath() + "/Task3.jsp";
//            response.sendRedirect(path);
//        }
//        else {
//            String path = request.getContextPath() + "/Task3.1.jsp";
//            response.sendRedirect(path);
//        }
    }
}
