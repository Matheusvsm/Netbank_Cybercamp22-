CREATE OR REPLACE FUNCTION public.updatemailnotification(
    "paramMailNotificationId" bigint,
    "paramAttempts" integer,
    "paramSendStatus" integer,
    "paramUserId" bigint)
    RETURNS void
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
Update public."MailNotification"
        SET
                "SentDate" = now(),
                "Attempts" = "paramAttempts",
                "SendStatus" = "paramSendStatus",
                "UpdateDate" = now(),
                "CreationUserId" ="paramUserId",
                "UpdateUserId" = "paramUserId"
         WHERE
            "DeletionDate" IS NULL AND
            "MailNotificationId" = "paramMailNotificationId"
$BODY$;
ALTER FUNCTION public.updatemailnotification(bigint, integer, integer,  bigint)
    OWNER TO "OSB";