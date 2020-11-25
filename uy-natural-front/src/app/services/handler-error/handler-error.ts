import {HttpErrorResponse} from "@angular/common/http";
import {throwError} from "rxjs";

export class HandlerError {

  constructor() {
  }

  handleError(error: HttpErrorResponse) {
    let message: string;

    if (error.error instanceof ErrorEvent) message = "Error: try it again"
    else if (error.status == 0) message = "The server is shutdown"
    else if (error.error.Description) message = error.error.Description
    else message = error.error.errors[Object.keys(error.error.errors)[0]][0]

    return throwError(message);
  }
}
