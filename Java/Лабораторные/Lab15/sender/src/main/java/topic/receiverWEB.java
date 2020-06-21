package topic;

import com.sun.messaging.Topic;
import com.sun.messaging.TopicConnectionFactory;

import javax.jms.*;
import javax.naming.Context;
import javax.naming.InitialContext;
import javax.naming.NamingException;
import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.util.Properties;

public class receiverWEB {
    public static void main(String[] args) throws JMSException {
        try
        { //создать соединение
            InitialContext ctx=new InitialContext();
            QueueConnectionFactory f=
                    (QueueConnectionFactory)ctx.lookup("java:comp/DefaultJMSConnectionFactory ");
            QueueConnection con=f.createQueueConnection();
            con.start();
//2) создать queue session
            QueueSession session=
                    con.createQueueSession(false, Session.AUTO_ACKNOWLEDGE);
//3) получить Queue object
            Queue queue=(Queue)ctx.lookup("Topic");
//4)создать QueueSender object
            QueueSender sender=session.createSender(queue);
//5) создатть TextMessage object
            ObjectMessage msg=session.createObjectMessage();
            //6) записать сообщение
            BufferedReader b=
                    new BufferedReader(new InputStreamReader(System.in));
            while(true)
            {
                System.out.println("Enter Msg, end to terminate:");
                String s=b.readLine();
                if (s.equals("end"))
                    break;
                MyClass myClass = new MyClass();
                msg.setObject(myClass);
//7) послать
                sender.send(msg);
                System.out.println("Message successfully sent.");
            }
//8) закрыть
            con.close();
        }catch(Exception e){System.out.println(e);}
    }
}
