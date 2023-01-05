CREATE OR REPLACE FUNCTION public.updatesmsnotification(
    "paramSmsNotificationId" bigint,
    "paramAttempts" integer,
    "paramSendStatus" integer,
    "paramUserId" bigint)
    RETURNS void
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
Update public."SmsNotification"
        SET
                "SentDate" = now(),
                "Attempts" = "paramAttempts",
                "SendStatus" = "paramSendStatus",
                "UpdateDate" = now(),
                "CreationUserId" = "paramUserId",
                "UpdateUserId" = "paramUserId"
         WHERE
            "DeletionDate" IS NULL AND
            "SmsNotificationId" = "paramSmsNotificationId"
$BODY$;
ALTER FUNCTION public.updatesmsnotification(bigint,  integer, integer, bigint)
    OWNER TO "OSB";