package DataBase;

import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;

public class Queries {
    public static ResultSet BOOK_YEAR(Statement stat) throws SQLException {
        return stat.executeQuery("SELECT * FROM books WHERE date BETWEEN 2019 AND 2020");
    }
    public static ResultSet AUTHOR_INFO(Statement stat) throws SQLException {
        return stat.executeQuery("SELECT * FROM AUTHOR");
    }
    public static ResultSet AUTHOR_INFO_BOOKCOUNT(Statement stat) throws SQLException {
        return stat.executeQuery("SELECT author.name, author.country, count(*) AS Книги FROM books INNER JOIN author ON books.author_name = author.name GROUP BY author.name, author.country HAVING Книги >= 2");
    }
    public static ResultSet DELETE_BOOK(Statement stat, PreparedStatement ps) throws SQLException {
        ps.setString(1, "2019");
        ps.executeUpdate();
        return stat.executeQuery("SELECT * FROM books");
    }
    public static ResultSet logpass(Statement stat) throws SQLException {
        return stat.executeQuery("select * from logpass");
    }
}
