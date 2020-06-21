import javax.servlet.*;
import javax.servlet.annotation.WebFilter;
import javax.servlet.http.Cookie;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;
import java.io.FileReader;
import java.io.IOException;
import java.util.ArrayList;
import java.util.Date;
import java.util.Scanner;

@WebFilter(filterName = "Filter", urlPatterns = "/Task3Main/*")
public class Filter implements javax.servlet.Filter {
    public void destroy() {
    }

    public void doFilter(ServletRequest req, ServletResponse resp, FilterChain chain) throws ServletException, IOException {

        HttpServletRequest request = (HttpServletRequest)req;
        HttpServletResponse response = (HttpServletResponse)resp;
        Cookie[] cookies = request.getCookies();
        FileReader fr= new FileReader("C:\\Users\\Dmitry\\Desktop\\labs\\Java\\Лабораторные\\Lab101\\users.txt");
        Scanner scan = new Scanner(fr);
        ArrayList<String> users = new ArrayList();
        while (scan.hasNextLine()) {
            users.add(scan.nextLine());
        }
        fr.close();
        Boolean flag = false;
        for (String str: users) {
            String[] arr = new String[3];
            arr = str.split(" ");
            if(cookies !=null) {
                for(Cookie c: cookies) {
                    if(arr[1].equals(c.getName())) {
                        flag = true;
                        break;
                    }
                }
            }
        }
        if(flag) {
            String path = request.getContextPath() + "/Task3.jsp";
            response.sendRedirect(path);
        }
        else {
            String path = request.getContextPath() + "/Task3.1.jsp";
            response.sendRedirect(path);
        }
    }

    public void init(FilterConfig config) throws ServletException {

    }

}
