package topic;

import com.sun.messaging.jms.JMSException;

import javax.jms.Message;
import javax.jms.MessageListener;
import javax.jms.ObjectMessage;

public class MyListener  implements MessageListener {

    @Override
    public void onMessage(Message m) {
        if (m instanceof ObjectMessage) {
            ObjectMessage objectMessage = (ObjectMessage) m;
            MyClass msg = null;
            try {
                msg = (MyClass)objectMessage.getObject();
            } catch (JMSException e) {
                e.printStackTrace();
            } catch (javax.jms.JMSException e) {
                e.printStackTrace();
            }
            System.out.println("following message is received: "+msg.toString());
        }
    }
}
