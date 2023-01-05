CREATE OR REPLACE FUNCTION public.getsmslistbystatus(
    "paramSendStatus" integer
    )
    RETURNS TABLE(
    "SmsNotificationId" bigint,
    "CompanyId" bigint ,
    "PhoneTo" character varying,
    "Content" character varying,
    "SentDate" timestamp ,
    "Attempts" integer ,
    "SendStatus" integer,
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
    "SmsNotificationId",
    "CompanyId",
    "PhoneTo" ,
    "Content" ,
    "SentDate" ,
    "Attempts" ,
    "SendStatus",
    "CreationDate",
    "UpdateDate",
    "DeletionDate" ,
    "CreationUserId",
    "UpdateUserId" 
    FROM
    public."SmsNotification" 
WHERE
    "DeletionDate" IS NULL AND
    "SendStatus"="paramSendStatus";
$BODY$;
ALTER FUNCTION public.getsmslistbystatus(integer)
    OWNER TO "OSB";