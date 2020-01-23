import { QuoteResponse } from './quote.response';

export interface QuoteUserResponse {
    id: string;
    quote: QuoteResponse;
    number: number;
}
