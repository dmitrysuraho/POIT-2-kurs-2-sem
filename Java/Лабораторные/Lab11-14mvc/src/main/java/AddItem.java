import DataBase.ConnectionDB;

import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;
import java.io.PrintWriter;
import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.SQLException;
import java.sql.Statement;

@WebServlet(name = "AddItem", urlPatterns = "/addItem")
public class AddItem extends HttpServlet {
    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        String item = request.getParameter("item");
        String price = request.getParameter("price");
        String quantity = request.getParameter("quantity");
        try{
            Connection cn = ConnectionDB.getConnection();
            Statement st = ConnectionDB.statement(cn);

            PreparedStatement ps = cn.prepareStatement("insert into buildingstore(item, price, quantity) values(?, ?, ?)");
            ps.setString(1, item);
            ps.setInt(2, Integer.parseInt(price));
            ps.setInt(3, Integer.parseInt(quantity));
            ps.executeUpdate();

            String path = request.getContextPath() + "/welcome.jsp";
            response.sendRedirect(path);
        } catch (SQLException e) {
            PrintWriter pw = response.getWriter();
            pw.println(e.getMessage());
        }
    }

    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {

    }
}
