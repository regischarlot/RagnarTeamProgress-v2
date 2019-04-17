export class RagnarResponse extends Response
{
	public success: boolean;
	public errorMessage: string;
	public elapsed: number;
	public data: any;
}

