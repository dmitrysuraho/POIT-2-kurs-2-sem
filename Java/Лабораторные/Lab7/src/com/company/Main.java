package com.company;

import DataBase.ConnectionDB;
import DataBase.CreateStatement;
import DataBase.PreStatement;
import DataBase.Queries;

import java.sql.*;

public class Main {

    public static void main(String[] args) throws SQLException {
        Connection cn = ConnectionDB.getConnection();
        Statement st = CreateStatement.statement(cn);
//
        System.out.println();
        ResultSet rs = Queries.logpass(st);
        while(rs.next())
        {
            System.out.println(rs.getString(1) + rs.getString(2));
        }
//        ResultSet rs = Queries.BOOK_YEAR(st);
//        while(rs.next()) {
//            System.out.println("Книга: " + rs.getString(1) + ", автор: " + rs.getString(2) +
//                    ", год выпуска: " + rs.getString(3) + ", издание: " + rs.getString(4));
//        }
//        System.out.println();
//        rs = Queries.AUTHOR_INFO(st);
//        while(rs.next()) {
//            System.out.println("Имя: " + rs.getString(1) + ", страна: " + rs.getString(2));
//        }
//        System.out.println();
//        rs = Queries.AUTHOR_INFO_BOOKCOUNT(st);
//        while(rs.next()) {
//            System.out.println("Имя: " + rs.getString(1) + ", страна: " + rs.getString(2) +
//                    ", кол-во книг: " + rs.getString(3));
//        }
//        PreparedStatement ps = PreStatement.getPreparedStatement(cn);
//        rs = Queries.DELETE_BOOK(st, ps);
//        while(rs.next()) {
//            System.out.println("Книга: " + rs.getString(1) + ", автор: " + rs.getString(2) +
//                    ", год выпуска: " + rs.getString(3) + ", издание: " + rs.getString(4));
//        }
//        System.out.println();

//        ConnectionDB.closeConnection(cn, st);

//        System.out.println("-----Транзакция------");
//        Connection connection = DriverManager.getConnection(
//                "jdbc:mysql://localhost:3306/java"+
//                        "?verifyServerCertificate=false"+
//                        "&useSSL=false"+
//                        "&requireSSL=false"+
//                        "&useLegacyDatetimeCode=false"+
//                        "&amp"+
//                        "&serverTimezone=UTC",
//                "root",
//                "12345"
//        );
//        connection.setAutoCommit(false); // режим неавтоматического подтверждения операций
//        try {
//            Statement stat = connection.createStatement();
//            ResultSet result = stat.executeQuery("SELECT * FROM author");
//            System.out.println("Старые данные:");
//            while (result.next()) {
//                System.out.println("Имя: " + result.getString(1) + ", страна: " + result.getString(2));
//            }
//            stat.executeUpdate("UPDATE author SET country='Беларусь' WHERE country='Америка'");
//            connection.commit();
//        }
//        catch (SQLException e) {
//            System.err.print("SQLState: " + e.getSQLState()
//            + "\nError message: " + e.getMessage());
//            connection.rollback();
//        }
    }
}
