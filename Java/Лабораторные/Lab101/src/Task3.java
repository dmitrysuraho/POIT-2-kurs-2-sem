import com.sun.deploy.net.HttpRequest;
import javafx.scene.chart.XYChart;

import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.*;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
import java.io.PrintWriter;
import java.lang.reflect.Array;
import java.sql.Connection;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;
import java.util.Scanner;

@WebServlet(name = "Task3", urlPatterns = "/Task3")
public class Task3 extends HttpServlet {
    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        HttpSession session = request.getSession();
        Integer countSess = (Integer) session.getAttribute("count");

        String login = request.getParameter("login");
        String pass = request.getParameter("pass");
        PrintWriter pw = response.getWriter();
        FileReader fr= new FileReader("C:\\Users\\Dmitry\\Desktop\\labs\\Java\\Лабораторные\\Lab101\\users.txt");
        Scanner scan = new Scanner(fr);
        int i = 1;
        ArrayList<String> users = new ArrayList();
        while (scan.hasNextLine()) {
            users.add(scan.nextLine());
        }
        fr.close();
        Boolean flag = false;
        String role = "";
        for (String str: users) {
            String[] arr = new String[3];
            arr = str.split(" ");
            if(arr[1].equals(login) && arr[2].equals(pass)) {
                if(countSess == null) {
                    session.setAttribute("count", 2);
                    countSess = 1;
                }
                else {
                    session.setAttribute("count", countSess + 1);
                }
                flag = true;
                role = arr[0];
                Cookie cookie = new Cookie(arr[1], arr[0] + " " + new Date().toString() + " " + countSess);
                response.addCookie(cookie);
                break;
            }
        }
        if(flag) {
            pw.println("Hello "+ role + " " + login + " " + new Date().toString() + " count: " + countSess);
        }
        else {
            pw.println("Check login or pass");
        }
    }

    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {

    }
}
