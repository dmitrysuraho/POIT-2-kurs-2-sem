
import javax.naming.InitialContext;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.Cookie;
import javax.servlet.jsp.JspWriter;
import javax.xml.transform.Result;
import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.PrintWriter;
import java.sql.Connection;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;
import java.util.Date;
import java.util.logging.Logger;


@WebServlet(name="servlet", urlPatterns = "/servlet")
public class servlet extends javax.servlet.http.HttpServlet {

    protected void doPost(javax.servlet.http.HttpServletRequest request, javax.servlet.http.HttpServletResponse response) throws javax.servlet.ServletException, IOException {
        Connection cn = null;
        try {
            ArrayList<person> list = new ArrayList<person>();
            cn = DBConnection.getConnection();
            Statement st = DBConnection.statement(cn);
            ResultSet rs = st.executeQuery("select * from ex");
            Boolean flag = false;
            person pers;
            Cookie[] cookies = request.getCookies();
            if(cookies == null) {
                pers = new person(rs.getString(1), rs.getString(2), rs.getString(3));
                Cookie cookie = new Cookie(pers.name, new Date().toString());
                response.addCookie(cookie);
                list.add(pers);
                request.setAttribute("list", pers);
            }
            else {
                while (rs.next()) {
                    for (Cookie c : cookies) {
                        if (!rs.getString(1).equals(c.getName())) {
                            pers = new person(rs.getString(1), rs.getString(2), rs.getString(3));
                            Cookie cookie = new Cookie(pers.name, new Date().toString());
                            response.addCookie(cookie);
                            request.setAttribute("list", pers);
                            break;
                        }
                    }
                }
            }




            request.getRequestDispatcher("/database.jsp").
                    forward(request, response);

            DBConnection.closeConnection(cn, st);
        } catch (SQLException e) {
            e.printStackTrace();
        }

    }

    protected void doGet(javax.servlet.http.HttpServletRequest request, javax.servlet.http.HttpServletResponse response) throws javax.servlet.ServletException, IOException {

    }

}
