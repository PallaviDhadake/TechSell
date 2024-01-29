<%@ Application Language="C#" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e)
    {
        // Code that runs on application startup
        RegisterRoutes(System.Web.Routing.RouteTable.Routes);

    }
    void RegisterRoutes(System.Web.Routing.RouteCollection routes)
    {
        routes.MapPageRoute("event-route", "events-gallery/{categId}/{myAlbumId}", "~/events.aspx", false, new System.Web.Routing.RouteValueDictionary {{ "categId", string.Empty }, { "myAlbumId", string.Empty }});

        routes.MapPageRoute("nws-route", "news/{newsId}", "~/news.aspx", false, new System.Web.Routing.RouteValueDictionary { { "newsId", string.Empty } });

        //routes.MapPageRoute("event-route", "events-gallery/{EvntId}", "~/events.aspx", false, new System.Web.Routing.RouteValueDictionary { { "EvntId", string.Empty } });

         routes.MapPageRoute("enquiry-route", "enquiry/{ProductId}", "~/enquiry.aspx", false, new System.Web.Routing.RouteValueDictionary {{ "ProductId", string.Empty }});

        routes.MapPageRoute("product-route", "product/{Category}/{ProductId}", "~/products.aspx", false, new System.Web.Routing.RouteValueDictionary { { "Category", string.Empty }, { "ProductId", string.Empty } });

        // routes.MapPageRoute("enquiry-route", "enquiry", "~/enquiry.aspx");


        //routes.MapPageRoute("book-route", "book-publication/{bookId}", "~/book-publication.aspx", false, new System.Web.Routing.RouteValueDictionary { { "bookId", string.Empty } });
        //routes.MapPageRoute("tour-route", "tours/{trType}", "~/tours.aspx", false, new System.Web.Routing.RouteValueDictionary { { "trType", string.Empty } });
        //routes.MapPageRoute("events-route", "events/{eventId}", "~/events.aspx", false, new System.Web.Routing.RouteValueDictionary { { "eventId", string.Empty } });
        //routes.MapPageRoute("qt-route", "get-quote/{placeId}", "~/get-quote.aspx", false, new System.Web.Routing.RouteValueDictionary { { "placeId", string.Empty } });
        routes.MapPageRoute("album-route", "photo-gallery/{albumId}", "~/photo-gallery.aspx", false, new System.Web.Routing.RouteValueDictionary { { "albumId", string.Empty } });
        routes.MapPageRoute("case-route", "case-studies/{caseId}", "~/case-studies.aspx", false, new System.Web.Routing.RouteValueDictionary { { "caseId", string.Empty } });

        routes.MapPageRoute("abt-route", "about-us", "~/about-us.aspx");
        // routes.MapPageRoute("prodcat-route", "product-category", "~/product-category.aspx");
        //routes.MapPageRoute("news-route", "news", "~/news.aspx");
        //routes.MapPageRoute("event-route", "events-gallery", "~/events.aspx");
        routes.MapPageRoute("career-route", "career", "~/career.aspx");
       
        routes.MapPageRoute("contact-route", "contact-us", "~/contact-us.aspx");
        routes.MapPageRoute("test-route", "testimonials", "~/testimonials.aspx");
        routes.MapPageRoute("appointment-route", "online-appointment", "~/online-appointment.aspx");
        routes.MapPageRoute("services-route", "services", "~/services.aspx");
        routes.MapPageRoute("award-route", "awards", "~/awards.aspx");
        routes.MapPageRoute("doctors-route", "doctors", "~/our-docters.aspx");
        routes.MapPageRoute("infertility-route", "infertility", "~/infertility.aspx");
        routes.MapPageRoute("facilities-route", "facilities", "~/facilities.aspx");
        routes.MapPageRoute("bnkboard-route", "bank-display-boards", "~/bank-display-boards.aspx");
        routes.MapPageRoute("streetlight-route", "street-lights", "~/street-lights.aspx");

    }

    void Application_End(object sender, EventArgs e)
    {
        //  Code that runs on application shutdown

    }

    void Application_Error(object sender, EventArgs e)
    {
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e)
    {
        // Code that runs when a new session is started

    }

    void Session_End(object sender, EventArgs e)
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }

</script>
