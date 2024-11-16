import { CanActivateFn } from '@angular/router';
import { AccountsService } from '../_services/accounts.service';
import { ToastrService } from 'ngx-toastr';
import { inject } from '@angular/core';

export const authGuard: CanActivateFn = (route, state) => {
  const accountService = inject(AccountsService);
  const toastr = inject(ToastrService);

  if (accountService.currentUser()) {
    return true;
  } else {
    toastr.error('You shall not pass !');
    return false;
  }
};
