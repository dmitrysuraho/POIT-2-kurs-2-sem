import DataBase.ConnectionDB;
import Store.BuildingStore;

import javax.servlet.annotation.WebServlet;
import javax.servlet.http.Cookie;
import javax.xml.transform.Result;
import java.io.IOException;
import java.io.PrintWriter;
import java.sql.Connection;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;
import java.util.Date;
import java.util.logging.Logger;


@WebServlet(name="login", urlPatterns = "/login")
public class login extends javax.servlet.http.HttpServlet {

    protected void doPost(javax.servlet.http.HttpServletRequest request, javax.servlet.http.HttpServletResponse response) throws javax.servlet.ServletException, IOException {
        Logger logger = Logger.getLogger(login.class.getName());
        try {
            String login = request.getParameter("login");
            String pass = request.getParameter("pass");
            PrintWriter pw = response.getWriter();
            Connection cn = ConnectionDB.getConnection();
            Statement st = ConnectionDB.statement(cn);
            ResultSet rs = st.executeQuery("select * from logpass");
            Boolean flag = false;
            while(rs.next()) {
                if(rs.getString(1).equals(login) &&
                        rs.getInt(2) == pass.hashCode()) {
                    flag = true;
                    break;
                }
            }
            if(flag) {
                Cookie cookie = new Cookie(login, new Date().toString());
                response.addCookie(cookie);

                ResultSet rs2 = st.executeQuery("select * from buildingstore");
                ArrayList<BuildingStore> list = new ArrayList<BuildingStore>();
                while(rs2.next()) {
                    list.add(new BuildingStore(rs2.getString(1), rs2.getInt(2), rs2.getInt(3)));
                }

                request.setAttribute("coll", list);
                request.getRequestDispatcher("/welcome.jsp").
                        forward(request, response);
                logger.info("correct login and password, WELCOME");
            }
            else {
                request.setAttribute("res", "wrong login or password");
                request.getRequestDispatcher("/login.jsp").
                        forward(request, response);
                logger.info("wrong login or password");
            }

            ConnectionDB.closeConnection(cn, st);
        } catch (SQLException e) {
            PrintWriter pw = response.getWriter();
            pw.println(e.getMessage());
            logger.info("error" + e);
    }
    }

    protected void doGet(javax.servlet.http.HttpServletRequest request, javax.servlet.http.HttpServletResponse response) throws javax.servlet.ServletException, IOException {

    }
}
