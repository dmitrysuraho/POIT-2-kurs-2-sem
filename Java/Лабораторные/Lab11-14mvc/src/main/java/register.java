import DataBase.ConnectionDB;

import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;
import java.io.PrintWriter;
import java.sql.*;
import java.util.logging.Logger;

@WebServlet(name = "register", urlPatterns = "/register")
public class register extends HttpServlet {

    private static final Logger logger = Logger.getLogger(register.class.getName());

    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        try {
            String login = request.getParameter("login");
            String pass = request.getParameter("pass");
            PrintWriter pw = response.getWriter();
            Connection cn = ConnectionDB.getConnection();
            Statement st = ConnectionDB.statement(cn);
            ResultSet rs = st.executeQuery("select * from logpass");
            Boolean flag = true;
            while(rs.next()) {
                if(rs.getString(1).equals(login)) {
                    flag = false;
                    break;
                }
            }
            if(login.isEmpty() || pass.isEmpty()){
                flag = false;
            }
            if(flag) {
                PreparedStatement ps = cn.prepareStatement("insert into logpass(login, pass) values(?, ?)");
                ps.setString(1, login);
                ps.setInt(2, pass.hashCode());
                ps.executeUpdate();

                String path = request.getContextPath() + "/login.jsp";
                response.sendRedirect(path);
                logger.info("you are reg");
            }
            else {
                request.setAttribute("reg", "wrong login or password");
                request.getRequestDispatcher("/register.jsp").
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

    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {

    }
}
