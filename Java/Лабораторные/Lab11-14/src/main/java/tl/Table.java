package tl;

import Store.BuildingStore;

import javax.servlet.jsp.JspException;
import javax.servlet.jsp.JspWriter;
import javax.servlet.jsp.tagext.TagSupport;
import java.io.IOException;
import java.util.GregorianCalendar;
import java.util.List;
import java.util.Locale;

@SuppressWarnings("serial")
public class Table extends TagSupport {
    public List<BuildingStore> list;

    public void setList(List<BuildingStore> list) {
        this.list = list;
    }

    @Override
    public int doStartTag() throws JspException {
        String str = "<table border='solid 1px black'>";
        for(BuildingStore x : list) {
            str += "<tr>" + "<td>" + x.item + "</td>" + "<td>" + x.price + "</td>" + "</tr>";
        }
        str += "</table>";
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
