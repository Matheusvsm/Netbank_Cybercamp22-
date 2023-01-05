CREATE OR REPLACE FUNCTION public.insertstaticpixqrcode(
	"paramExternalIdentifier" bigint,
  "paramQRCode" character varying,
  "paramHashCode" character varying,
  "paramPixKeyType" integer,
	"paramUserId" bigint,
	"paramAccountId" bigint)
  RETURNS TABLE("StaticPixQRCodeId" bigint)
  LANGUAGE 'sql'
  COST 100
  VOLATILE PARALLEL UNSAFE
AS $BODY$
INSERT INTO public."StaticPixQRCode"
(
  "UserId",
  "AccountId",
  "ExternalIdentifier",
  "QRCode",
  "HashCode",
  "PixKeyType",
  "CreationDate",
	"UpdateDate",
  "DeletionDate",
  "CreationUserId",
  "UpdateUserId"
)
VALUES
(
  "paramUserId",
  "paramAccountId",
  "paramExternalIdentifier",
  "paramQRCode",
  "paramHashCode",
  "paramPixKeyType",
  now(),
  now(),
  null,
  "paramUserId",
  "paramUserId"
)
RETURNING "StaticPixQRCodeId"
$BODY$;

ALTER FUNCTION public.insertstaticpixqrcode(bigint, character varying, character varying, integer, bigint, bigint)
    OWNER TO "OSB";