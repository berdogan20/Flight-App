/* tslint:disable */
/* eslint-disable */
import { HttpClient, HttpContext, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { filter, map } from 'rxjs/operators';
import { StrictHttpResponse } from '../../strict-http-response';
import { RequestBuilder } from '../../request-builder';


export interface CancelBooking$Params {
  FlightId?: string;
  PassengerEmail?: string;
  NumberOfSeats?: number;
}

export function cancelBooking(http: HttpClient, rootUrl: string, params?: CancelBooking$Params, context?: HttpContext): Observable<StrictHttpResponse<void>> {
  const rb = new RequestBuilder(rootUrl, cancelBooking.PATH, 'delete');
  if (params) {
    rb.query('FlightId', params.FlightId, {});
    rb.query('PassengerEmail', params.PassengerEmail, {});
    rb.query('NumberOfSeats', params.NumberOfSeats, {});
  }

  return http.request(
    rb.build({ responseType: 'text', accept: '*/*', context })
  ).pipe(
    filter((r: any): r is HttpResponse<any> => r instanceof HttpResponse),
    map((r: HttpResponse<any>) => {
      return (r as HttpResponse<any>).clone({ body: undefined }) as StrictHttpResponse<void>;
    })
  );
}

cancelBooking.PATH = '/Booking';
