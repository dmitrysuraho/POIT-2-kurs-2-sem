package tl;

import javax.servlet.jsp.JspException;
import javax.servlet.jsp.JspWriter;
import javax.servlet.jsp.tagext.TagSupport;
import java.io.IOException;
import java.util.GregorianCalendar;
import java.util.Locale;

public class Submit extends TagSupport {
    @Override
    public int doStartTag() throws JspException {
        String str = "<input type='submit' value='Log in'/><form action='register' method='post'><input type='submit' value='Registration'/></form>";
        try {
            JspWriter out = pageContext.getOut();
            out.write(str);
        } catch (IOException e) {
            throw new JspException(e.getMessage());
        }
        return SKIP_BODY;
    }
    @Override
    public int doEndTag() throws JspException {
        return EVAL_PAGE;
    }
}
