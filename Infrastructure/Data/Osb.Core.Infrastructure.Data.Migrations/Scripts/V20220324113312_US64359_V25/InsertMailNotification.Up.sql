CREATE OR REPLACE FUNCTION public.insertmailnotification(
    "paramCompanyId" bigint,
    "paramMailTo" character varying,
    "paramContent" character varying,
    "paramSendStatus" integer ,
    "paramSubject" character varying,
    "paramUserId" bigint)
    RETURNS TABLE("MailNotificationId" bigint)
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000
AS $BODY$
INSERT INTO public."MailNotification"
                    (
                "CompanyId",
                "MailTo",
                "Content" ,
                "SendStatus",
                "Subject",
                "CreationDate",
                "UpdateDate",                   
                "CreationUserId",
                "UpdateUserId"
                     )
                VALUES (
                "paramCompanyId",
                "paramMailTo",
                "paramContent" ,
                "paramSendStatus",
                "paramSubject",
                now(),
                now(),
                "paramUserId",
                "paramUserId"
                    ) RETURNING "MailNotificationId"
$BODY$;
ALTER FUNCTION public.insertmailnotification(bigint, character varying, character varying, integer, character varying, bigint)
    OWNER TO "OSB";