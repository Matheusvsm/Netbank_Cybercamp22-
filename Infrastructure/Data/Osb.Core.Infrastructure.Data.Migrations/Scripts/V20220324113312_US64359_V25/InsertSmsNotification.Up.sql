CREATE OR REPLACE FUNCTION public.insertsmsnotification(
    "paramCompanyId" bigint,
    "paramPhoneTo" character varying,
    "paramContent" character varying,
    "paramSendStatus" integer,
    "paramUserId" bigint)
    RETURNS TABLE("SmsNotificationId" bigint)
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000
AS $BODY$
INSERT INTO public."SmsNotification"
                    (
                "CompanyId",
                "PhoneTo",
                "Content" ,
                "SendStatus",
                "CreationDate",
                "UpdateDate",                   
                "CreationUserId",
                "UpdateUserId"
                     )
                VALUES (
                "paramCompanyId",
                "paramPhoneTo",
                "paramContent",
                "paramSendStatus",
                 now(),
                 now(),
                 "paramUserId",
                 "paramUserId"
                    ) RETURNING "SmsNotificationId"
$BODY$;
ALTER FUNCTION public.insertsmsnotification(bigint, character varying, character varying, integer, bigint)
    OWNER TO "OSB";