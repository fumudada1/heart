<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
    <xsl:output method="html" version="4.0" encoding="Big5" indent="yes"/>

    <xsl:param name="permission" select="'A01,A02,A03,A04'" /> <!--權限參數-->
    <xsl:param name="moduleID" select="''" /> <!--目前使用的ModuleID參數-->
    
    <xsl:template match="menu">

        <ul id="flyout">

            <xsl:apply-templates select="Modules" />
        </ul>

    </xsl:template>
    <xsl:template match="Modules">
        <xsl:if test="contains($permission,@value)"> <!--判斷是否有權限-->
            <xsl:variable name="className" ><!--宣告class變數-->
                <xsl:choose>
                    <xsl:when test="contains($moduleID,@value)">fly current</xsl:when> <!--如果在使用中使用fly current 類別-->
                    <xsl:otherwise>fly</xsl:otherwise>
                </xsl:choose>
            </xsl:variable>
            <xsl:variable name="className1" >
                <!--宣告class變數-->
                <xsl:choose>
                    <xsl:when test="contains($moduleID,@value)">current</xsl:when>
                </xsl:choose>
            </xsl:variable>
            
            <xsl:choose>
                <xsl:when test="Modules"> <!--如果還有子節點進遞迴-->

                    <li>
                        <a class="{$className}"  href="{@url}">
                            <b>
                                <xsl:value-of select="@Title" />
                            </b>
                            <!--[if gte IE 7]><!-->
                            <xsl:comment>[if gte IE 7]&gt;&lt;!</xsl:comment>
                        </a>
                        <!--<![endif]-->
                        <xsl:comment>-&lt;![endif]</xsl:comment>
                        <!--[if lte IE 6]><table><tr><td><![endif]-->
                        <xsl:comment>[if lte IE 6]&gt;&lt;table&gt;&lt;tr&gt;&lt;td&gt;&lt;![endif]</xsl:comment>
                        <ul>


                            <xsl:apply-templates select="Modules" /> <!--進遞迴-->


                        </ul>
                        <xsl:comment>[if lte IE 6]&gt;&lt;/td&gt;&lt;/tr&gt;&lt;/table&gt;&lt;/a&gt;&lt;![endif]</xsl:comment>

                    </li>


                </xsl:when>
                <xsl:otherwise> <!--leaf node-->
                    <li>
                        <a class="{$className1}" href="{@url}">
                            <b>
                                <xsl:value-of select="@Title" />
                            </b>
                        </a>

                    </li>
                </xsl:otherwise>
            </xsl:choose>
        </xsl:if>

    </xsl:template>

</xsl:stylesheet>
