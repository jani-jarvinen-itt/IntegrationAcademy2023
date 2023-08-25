<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
    <xsl:output method="html"/>
    
    <xsl:template match="/">
        <html>
            <head>
                <title>Library</title>
            </head>
            <body>
                <h1>Book List</h1>
                <ul>
                    <xsl:apply-templates select="library/book"/>
                </ul>
            </body>
        </html>
    </xsl:template>
    
    <xsl:template match="book">
        <li>
            <strong><xsl:value-of select="title"/></strong> by <xsl:value-of select="author"/>
        </li>
    </xsl:template>

</xsl:stylesheet>
