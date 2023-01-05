CREATE OR REPLACE FUNCTION public.getmaillistbystatus(
    "paramSendStatus" integer
    )
    RETURNS TABLE(
    "MailNotificationId" bigint,
    "CompanyId" bigint ,
    "MailTo" character varying,
    "Content" character varying,
    "SentDate" timestamp ,
    "Attempts" integer ,
    "SendStatus" integer,
    "Subject" character varying,
    "CreationDate" timestamp ,
    "UpdateDate" timestamp ,
    "DeletionDate" timestamp ,
    "CreationUserId" bigint ,
    "UpdateUserId" bigint )
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000
AS $BODY$
SELECT
    "MailNotificationId",
    "CompanyId",
    "MailTo" ,
    "Content" ,
    "SentDate" ,
    "Attempts" ,
    "SendStatus",
    "Subject",
    "CreationDate",
    "UpdateDate",
    "DeletionDate" ,
    "CreationUserId",
    "UpdateUserId" 
    FROM
    public."MailNotification" 
WHERE
    "DeletionDate" IS NULL AND
    "SendStatus"="paramSendStatus";
$BODY$;
ALTER FUNCTION public.getmaillistbystatus(integer)
    OWNER TO "OSB";