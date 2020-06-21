import DataBase.ConnectionDB;
import Store.BuildingStore;

import javax.servlet.*;
import javax.servlet.annotation.WebFilter;
import javax.servlet.http.Cookie;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.FileReader;
import java.io.IOException;
import java.io.PrintWriter;
import java.sql.Connection;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;
import java.util.Scanner;

@WebFilter(filterName = "Filter", urlPatterns = "/welcome.jsp")
public class Filter implements javax.servlet.Filter {
    public void destroy() {
    }

    public void doFilter(ServletRequest req, ServletResponse resp, FilterChain chain) throws ServletException, IOException {
        chain.doFilter(req, resp);
        HttpServletRequest request = (HttpServletRequest) req;
        HttpServletResponse response = (HttpServletResponse) resp;
        try {
            Connection cn = ConnectionDB.getConnection();
            Statement st = ConnectionDB.statement(cn);
            ResultSet rs = st.executeQuery("select * from logpass");
            Cookie[] cookies = request.getCookies();
            Boolean flag = false;
            if (cookies != null) {
                while(rs.next()) {
                    for (Cookie c : cookies) {
                        if (rs.getString(1).equals(c.getName())) {
                            flag = true;
                            break;
                        }
                    }
                }
            }
            if (!flag){
                String path = request.getContextPath() + "/errorPage.jsp";
                response.sendRedirect(path);
            }

            ResultSet rs2 = st.executeQuery("select * from buildingstore");
            ArrayList<BuildingStore> list = new ArrayList<BuildingStore>();
            while(rs2.next()) {
                list.add(new BuildingStore(rs2.getString(1), rs2.getInt(2), rs2.getInt(3)));
            }

            request.setAttribute("coll", list);
        } catch (SQLException e) {
            PrintWriter pw = response.getWriter();
            pw.println(e.getMessage());
        }
    }

    public void init(FilterConfig config) throws ServletException {

    }

}
