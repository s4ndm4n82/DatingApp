import { HttpInterceptorFn } from '@angular/common/http';
import { AccountsService } from '../_services/accounts.service';
import { inject } from '@angular/core';

export const jwtInterceptor: HttpInterceptorFn = (req, next) => {
  const accountService = inject(AccountsService);

  if (accountService.currentUser) {
    req = req.clone({
      setHeaders: {
        Authorization: `Bearer ${accountService.currentUser()?.token}`,
      },
    });
  }

  return next(req);
};
