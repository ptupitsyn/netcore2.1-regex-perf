﻿using System;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace regex_test
{
    class Program
    {
        private static readonly string PackageString =
            "grub-common,geoip-database,iptables,friendly-recovery,readline-common,liberror-perl,libstdc++6,libncursesw5,htop,golang-1.10-src,libisccfg140,libtext-charwidth-perl,libc6,iso-codes,libpython2.7-minimal,libprocps4,libparted2,ncurses-bin,openssl,libssl1.0.0,libexpat1,dash,zip,accountsservice,ubuntu-keyring,language-pack-en,libcryptsetup4,binutils,less,discover,python-minimal,ncurses-term,libxau6,libpython3.5-minimal,libpython2.7-stdlib,libpcap0.8,libasprintf0v5,installation-report,debconf,libxcb1,libkmod2,iputils-tracepath,dnsutils,python-software-properties,libpython-stdlib,libbsd0,lsb-base,libx11-6,libdns-export162,unzip,fakeroot,libidn11,tree,libxml2,liblwres141,time,libtasn1-6,libhcrypto4-heimdal,libgssapi-krb5-2,libc-dev-bin,mawk,xauth,popularity-contest,diffutils,mount,libdrm2,dbus,plymouth-theme-ubuntu-text,libfdisk1,cpio,libasn1-8-heimdal,libalgorithm-diff-perl,gettext-base,laptop-detect,gpgv,resolvconf,manpages-dev,libfile-fcntllock-perl,cgroupfs-mount,libsasl2-modules,systemd-sysv,screen,ltrace,lshw,python2.7-minimal,libpython3.5-stdlib,kmod,hostname,libcilkrts5,gcc-5,pkg-config,libpam-modules,liblocale-gettext-perl,libklibc,bsdmainutils,aufs-tools,linux-image-4.13.0-36-generic,libmpc3,libldap-2.4-2,libapt-pkg5.0,libapparmor-perl,tcpdump,python3-pkg-resources,libroken18-heimdal,libitm1,ubuntu-advantage-tools,libelf1,libpci3,gnupg,vim-common,udev,make,libcurl3-gnutls,insserv,xkb-data,libsasl2-2,sysvinit-utils,plymouth,python3-chardet,libicu55,git,bzip2,util-linux,python3-commandnotfound,sysv-rc,parted,libpopt0,libmpdec2,krb5-locales,libpython3-stdlib,apt-transport-https,debconf-i18n,libcc1-0,libssh2-1,libglib2.0-data,curl,mlocate,libpcre3,libgeoip1,base-passwd,tasksel-data,python3-urllib3,uuid-runtime,tcpd,libkrb5-3,irqbalance,mc,liblzma5,kbd,cron,libc-bin,keyboard-configuration,python3-requests,python3-gi,libnih1,libglib2.0-0,bash-completion,makedev,libstdc++-5-dev,coreutils,libnewt0.52,lsof,libsmartcols1,ubuntu-minimal,sed,linux-headers-4.13.0-36,libdbus-1-3,libatomic1,grub2-common,busybox-static,libpam-runtime,python3-apt,ncurses-base,klibc-utils,shared-mime-info,multiarch-support,mc-data,libk5crypto3,libheimbase1-heimdal,tasksel,language-pack-en-base,e2fsprogs,rsyslog,libsemanage-common,python-pycurl,libtext-wrapi18n-perl,libasan2,fuse,python3-software-properties,libss2,libseccomp2,libdns162,libdevmapper1.02.1,ifupdown,dpkg-dev,sgml-base,pigz,libpam-modules-bin,console-setup-linux,linux-headers-4.13.0-36-generic,libquadmath0,libisl15,libgdbm3,dosfstools,zlib1g,procps,python3,gcc,ureadahead,python,xdg-user-dirs,libselinux1,passwd,liblsan0,libusb-0.1-4,libplymouth4,libmnl0,isc-dhcp-client,gcc-5-base,usbutils,python3.5,libtext-iconv-perl,libmpfr4,libmount1,libbz2-1.0,initramfs-tools-bin,libusb-1.0-0,libdebconfclient0,libc6-dev,distro-info-data,sensible-utils,mime-support,file,tzdata,g++,libxmuu1,base-files,libaudit1,initscripts,libapt-inst2.0,libisc160,libgnutls30,libcap2-bin,init,gcc-6-base,whiptail,libalgorithm-merge-perl,iputils-ping,python3-gdbm,openssh-server,libsemanage1,libgpg-error0,libkeyutils1,libdrm-common,iproute2,grub-pc,strace,git-man,logrotate,libpam0g,libgcc-5-dev,libxtables11,libblkid1,libalgorithm-diff-xs-perl,locales,install-info,software-properties-common,linux-base,libgpm2,tar,liblz4-1,libfreetype6,ucf,libx11-data,libudev1,libtsan0,libgomp1,net-tools,mtr-tiny,libuuid1,libisccc140,libpipeline1,debianutils,build-essential,libheimntlm0-heimdal,discover-data,wget,libcap-ng0,gzip,grub-pc-bin,pciutils,python3-update-manager,powermgmt-base,libncurses5,libkrb5-26-heimdal,libisc-export160,libaudit-common,bsdutils,libp11-kit0,init-system-helpers,info,libpam-systemd,bash,libpng12-0,apt,libslang2,language-selector-common,hdparm,groff-base,libsepol1,findutils,python3-six,ntfs-3g,libustr-1.0-1,dpkg,docker-ce,systemd,libhx509-5-heimdal,ftp,command-not-found,libwind0-heimdal,golang-1.10-race-detector-runtime,rsync,libreadline6,libaccountsservice0,ubuntu-release-upgrader-core,ssh-import-id,perl-modules-5.22,libcomerr2,grep,libsasl2-modules-db,libattr1,libmagic1,libcap2,golang-1.10-go,python3-pycurl,libgnutls-openssl27,python-apt,libgssapi3-heimdal,ubuntu-standard,libnettle6,vim-tiny,python3-distupgrade,libhogweed4,libfribidi0,perl-base,apparmor,gdisk,patch,linux-libc-dev,adduser,python2.7,libgcc1,libatm1,dh-python,openssh-sftp-server,libnfnetlink0,libgcrypt20,apt-utils,libapparmor1,ca-certificates,python3-minimal,console-setup,librtmp1,openssh-client,libperl5.22,libfuse2,libdbus-glib-1-2,initramfs-tools-core,cpp-5,libdiscover2,grub-gfxpayload-lists,libsystemd0,libmpx0,libedit2,g++-5,bind9-host,libdpkg-perl,libdb5.3,e2fslibs,netbase,libtinfo5,libestr0,gir1.2-glib-2.0,eject,libfakeroot,dmidecode,psmisc,libnuma1,libjson-c2,sudo,libxdmcp6,libacl1,netcat-openbsd,login,libltdl7,ed,busybox-initramfs,update-manager-core,libffi6,python-apt-common,perl,man-db,isc-dhcp-common,xml-core,libkrb5support0,command-not-found-data,xz-utils,lsb-release,libpolkit-gobject-1-0,manpages,libxext6,libsqlite3-0,libwrap0,libbind9-140,cpp,libgmp10,libgirepository-1.0-1,libubsan0,nano,telnet,os-prober,python3-dbus,python3.5-minimal,initramfs-tools";

        public static string FilterString { get; } =
            "ActiveMQ[VERSION],amavisd[VERSION],amavisd[VERSION]-new[VERSION],ant[VERSION],apache[VERSION],apache[VERSION]-server[VERSION],bacula-fd[VERSION],bison[VERSION],bsd-mailx[VERSION],cassandra[VERSION],chef[VERSION],chef[VERSION]-server[VERSION],chef[VERSION]-server[VERSION]-core[VERSION],chef[VERSION]-zero[VERSION],chrome[VERSION],chromium[VERSION],chromium[VERSION]-browser[VERSION],datastax[VERSION]-agent[VERSION],dcron[VERSION],derby[VERSION]-javadb[VERSION],docker[VERSION],docker[VERSION]-containerd[VERSION],docker[VERSION]-ce[VERSION],docker[VERSION]-ee[VERSION],docker[VERSION]-engine[VERSION],docker[VERSION]-io[VERSION],docker[VERSION].io[VERSION],dos2unix[VERSION],dovecot[VERSION],dovecot[VERSION]-imapd[VERSION],dovecot[VERSION]-lmtpd[VERSION],dovecot[VERSION]-pop3d[VERSION],dsc[VERSION],elasticsearch[VERSION],erlang[VERSION],exim[VERSION],fail2ban[VERSION],firefox[VERSION],fuse-libs[VERSION],gitlab[VERSION]-ce[VERSION],gitlab[VERSION]-ee[VERSION],gitweb[VERSION],Glassfish[VERSION],google-chrome[VERSION],google-chrome[VERSION]-beta[VERSION],google-chrome[VERSION]-stable[VERSION],google-chrome[VERSION]-unstable[VERSION],grafana[VERSION],graylog[VERSION],graylog[VERSION]-server[VERSION],haproxy[VERSION],httpd[VERSION],httpd[VERSION]-server[VERSION],hudson[VERSION],influxdb[VERSION],ibmmq[VERSION],inspec[VERSION],JasperReportServer[VERSION],java-jdk[VERSION],java[VERSION]-openjdk[VERSION],java[VERSION]-openjdk[VERSION]-devel[VERSION],java[VERSION]-openjdk[VERSION]-headless[VERSION],jboss[VERSION],jdk[VERSION],jdk[VERSION]_[VERSION],jenkins[VERSION],jline[VERSION],junit[VERSION],Kerberos Client[VERSION],Kerberos Server[VERSION],kerio-connect[VERSION],krb[VERSION],krb[VERSION]-workstation[VERSION],krb[VERSION]-user[VERSION],krb[VERSION]-server[VERSION],krb[VERSION]-admin-server[VERSION],ldap-utils[VERSION],libapache[VERSION]-mod-svn[VERSION],libderby[VERSION]-java[VERSION],log4j[VERSION],mailx[VERSION],mariadb[VERSION],mariadb[VERSION]-server[VERSION],maven[VERSION],mediawiki[VERSION],memcached[VERSION],mercurial[VERSION],mod[VERSION]_dav_svn[VERSION],mongodb[VERSION],mongodb[VERSION]-server[VERSION],monitoring[VERSION],monitoring[VERSION]-plugins[VERSION],munin[VERSION],munin[VERSION]-node[VERSION],munin[VERSION]-server[VERSION],mysql[VERSION],mysql[VERSION]-server[VERSION],Nagios Plugins[VERSION],nagios[VERSION],nagios[VERSION]-plugins[VERSION],newrelic[VERSION]-daemon[VERSION],newrelic[VERSION]-php[VERSION],newrelic[VERSION]-sysmond[VERSION],nginx[VERSION],nginx[VERSION]-extras[VERSION],nginx[VERSION]-full[VERSION],nodejs[VERSION],nodejs[VERSION]-npm[VERSION],npm[VERSION],nrpe[VERSION],opendkim[VERSION],openjdk[VERSION]-jdk[VERSION],openjdk[VERSION]-jdk-headless[VERSION],openjdk[VERSION]-jre[VERSION],openjdk[VERSION]-jre-headless[VERSION],openldap[VERSION],openvpn[VERSION],opscenter[VERSION],opsworks[VERSION]-agent[VERSION]-ruby[VERSION],oracle[VERSION]-rdbms[VERSION],OracleDB[VERSION],p7zip[VERSION],p7zip[VERSION]-full[VERSION],PagerDutyAgent[VERSION],pam_ldap[VERSION],percona[VERSION],percona[VERSION]-server[VERSION],pdagent[VERSION],phantomjs[VERSION],php[VERSION],php[VERSION]-cgi[VERSION],php[VERSION]-fpm[VERSION],php[VERSION]w[VERSION],pnp4nagios[VERSION],postfix[VERSION],postgresql[VERSION],postgresql[VERSION]-server[VERSION],Pound[VERSION],PowerMTA[VERSION],powershell[VERSION],proftpd[VERSION],puppet[VERSION],push-jobs[VERSION]-client[VERSION],push-jobs[VERSION]-server[VERSION],python3[VERSION],rabbitmq[VERSION],rabbitmq[VERSION]-server[VERSION],redis[VERSION],redis[VERSION]-server[VERSION],rh-git[VERSION],rh-java[VERSION]-common[VERSION],rh-maven[VERSION],rh-mongodb[VERSION],rh-mongodb[VERSION]-server[VERSION],rh-mysql[VERSION],rh-mysql[VERSION]-server[VERSION],rh-nginx[VERSION],rh-nodejs[VERSION],rh-perl[VERSION],rh-php[VERSION],rh-postgresql[VERSION],rh-postgresql[VERSION]-postgresql[VERSION]-server[VERSION],rh-postgresql[VERSION]-server[VERSION],rh-python[VERSION],rh-python[VERSION]-pip[VERSION],rh-rabbitmq[VERSION],rh-rabbitmq[VERSION]-server[VERSION],rh-redis[VERSION],rh-redis[VERSION]-server[VERSION],rh-ruby[VERSION],rh-ror[VERSION],ror[VERSION],ruby[VERSION],ruby[VERSION]-ruby[VERSION],ruby[VERSION]-chef[VERSION],samba[VERSION],samba[VERSION]-client[VERSION],samba[VERSION]-common[VERSION],sendmail[VERSION],serverbackup-agent[VERSION],slapd[VERSION],SonarQube[VERSION],spamassassin[VERSION],sphinx[VERSION],sphinxsearch[VERSION],squid[VERSION],subversion[VERSION],sun[VERSION]-javadb[VERSION],sun[VERSION]-javadb[VERSION]-core[VERSION],TeamCity Agent[VERSION],telnet[VERSION]-server[VERSION],telnetd[VERSION],thruk[VERSION],thruk[VERSION]-base[VERSION],thruk[VERSION]-plugin-reporting[VERSION],tomcat[VERSION],vsftpd[VERSION],webspheremq[VERSION],WebSphere MQ[VERSION],xorg[VERSION]-x[VERSION]-server[VERSION]-Xvfb[VERSION],xvfb[VERSION],ypbind[VERSION],zabbix[VERSION],zabbix[VERSION]-agent[VERSION],zabbix[VERSION]-proxy[VERSION]-mysql[VERSION],zabbix[VERSION]-proxy[VERSION]-pgsql[VERSION],zabbix[VERSION]-proxy[VERSION]-sqlite3[VERSION],zabbix[VERSION]-server[VERSION]-mysql[VERSION],zabbix[VERSION]-server[VERSION]-pgsql[VERSION],zookeeper[VERSION],cinnamon[VERSION],cinnamon[VERSION]-core[VERSION],desktop[VERSION],gnome[VERSION],gnome[VERSION]-desktop[VERSION],gnome[VERSION]-common[VERSION],gnome[VERSION]-themes[VERSION],gstreamer[VERSION],kde[VERSION]-plasma-desktop[VERSION],kde[VERSION]-plasma-netbook[VERSION],kde[VERSION]-standard[VERSION],lxde[VERSION],lxde[VERSION]-core[VERSION],lxde[VERSION]-common[VERSION],mate[VERSION]-desktop-environment[VERSION],mate[VERSION]-desktop-common[VERSION],pulseaudio[VERSION],rsh[VERSION],thunar[VERSION],vnc[VERSION]server[VERSION],unity[VERSION],unity[VERSION]-services[VERSION],xfdesktop[VERSION],xorg[VERSION],xorg-x11-drivers[VERSION],xserver[VERSION]-xorg[VERSION],xterm[VERSION],acpid[VERSION],adduser[VERSION],anacron[VERSION],apparmor[VERSION],apport[VERSION],apport-symptoms[VERSION],apt[VERSION],apt-transport-https[VERSION],apt-utils[VERSION],at[VERSION],attr[VERSION],augeas-lenses[VERSION],base-files[VERSION],base-passwd[VERSION],bash[VERSION],bash-completion[VERSION],bcache-tools[VERSION],binutils[VERSION],bsdmainutils[VERSION],bsdutils[VERSION],btrfs-tools[VERSION],busybox-initramfs[VERSION],busybox-static[VERSION],byobu[VERSION],bzip[VERSION],ca-certificates[VERSION],cloud-guest-utils[VERSION],cloud-initramfs-copymods[VERSION],cloud-initramfs-dyn-netconf[VERSION],command-not-found[VERSION],command-not-found-data[VERSION],console-setup[VERSION],console-setup-linux[VERSION],coreutils[VERSION],cpio[VERSION],cpu-checker[VERSION],crda[VERSION],cron[VERSION],cron[VERSION],crond[VERSION],cronie[VERSION],cryptsetup[VERSION],curl[VERSION],dash[VERSION],dbus[VERSION],debconf[VERSION],debconf-i18n[VERSION],debianutils[VERSION],dh-python[VERSION],diffutils[VERSION],distro-info-data[VERSION],dmeventd[VERSION],dmidecode[VERSION],dmsetup[VERSION],dns-root-data[VERSION],dnsmasq[VERSION],dnsutils[VERSION],dosfstools[VERSION],dpkg[VERSION],e2fslibs[VERSION],e2fsprogs[VERSION],ed[VERSION],eject[VERSION],ethtool[VERSION],extlinux[VERSION],fcron[VERSION],file[VERSION],findutils[VERSION],fontconfig[VERSION],fontconfig-config[VERSION],fonts-dejavu-core[VERSION],fonts-ubuntu-font-family-console[VERSION],friendly-recovery[VERSION],ftp[VERSION],fuse[VERSION],gawk[VERSION],gcc[VERSION],gdisk[VERSION],genisoimage[VERSION],geoip-database[VERSION],gettext[VERSION],gir[VERSION]-glib[VERSION],git[VERSION],git-man[VERSION],gnupg[VERSION],gpg-pubkey[VERSION],gpg-pubkey.(none)[VERSION],gpgv[VERSION],grep[VERSION],groff[VERSION],grub[VERSION],grub-gfxpayload-lists[VERSION],grub-legacy-ec[VERSION],grub-pc[VERSION],gzip[VERSION],hdparm[VERSION],hfsplus[VERSION],hicolor-icon-theme[VERSION],hostname[VERSION],ifenslave[VERSION],ifupdown[VERSION],info[VERSION],init[VERSION],init-system-helpers[VERSION],initramfs-tools[VERSION],initramfs-tools-core[VERSION],initscripts0[VERSION],insserv[VERSION],install-info[VERSION],installation-report[VERSION],iproute[VERSION],iptables[VERSION],iputils-ping[VERSION],iputils-tracepath[VERSION],ipxe-qemu[VERSION],irqbalance[VERSION],isc-dhcp[VERSION],isc-dhcp-client[VERSION],iso-codes[VERSION],ivtv[VERSION]-firmware[VERSION],iw[VERSION],iwl[VERSION]-firmware[VERSION],iwl[VERSION]g2a-firmware[VERSION],iwl[VERSION]g2b-firmware[VERSION],kbd[VERSION],kernel[VERSION],kernel-devel[VERSION],kernel-firmware[VERSION],kernel-headers[VERSION],kernel-tools[VERSION],kernel-tools-libs[VERSION],keyboard-configuration[VERSION],klibc-utils[VERSION],kmod[VERSION],krb5-locales[VERSION],language-pack-en[VERSION],language-selector[VERSION],laptop-detect[VERSION],less[VERSION],libaccountsservice[VERSION],libacl[VERSION],libaio[VERSION],libapparmor[VERSION],libapparmor-perl[VERSION],libapt-inst[VERSION],libapt-pkg[VERSION],libasn[VERSION]-heimdal[VERSION],libasound[VERSION],libasound[VERSION]-data[VERSION],libasprintf0v[VERSION],libasyncns[VERSION],libatk[VERSION],libatk[VERSION]-data[VERSION],libatm[VERSION],libattr[VERSION],libaudit[VERSION],libaugeas[VERSION],libauthen-sasl-perl[VERSION],libavahi-client[VERSION],libavahi-common[VERSION],libavahi-common-data[VERSION],libbind[VERSION],libblkid[VERSION],libbluetooth[VERSION],libboost-iostreams[VERSION],libboost-random[VERSION],libboost-system[VERSION],libboost-thread[VERSION],libbrlapi[VERSION],libbsd[VERSION],libbz[VERSION],libc[VERSION],libcaca[VERSION],libcacard[VERSION],libcairo[VERSION],libcap[VERSION],libcap-ng[VERSION],libcomerr[VERSION],libconfig[VERSION],libcryptsetup[VERSION],libcups[VERSION],libcurl[VERSION]-gnutls[VERSION],libdatrie[VERSION],libdb[VERSION],libdbus[VERSION],libdbus-glib[VERSION],libdebconfclient[VERSION],libdevmapper[VERSION],libdevmapper-event[VERSION],libdns[VERSION],libdns-export[VERSION],libdrm[VERSION],libdumbnet[VERSION],libedit[VERSION],libelf[VERSION],libencode-locale-perl[VERSION],liberror-perl[VERSION],libestr[VERSION],libevent[VERSION],libexpat[VERSION],libfdisk[VERSION],libfdt[VERSION],libffi[VERSION],libfile-listing-perl[VERSION],libflac[VERSION],libfont-afm-perl[VERSION],libfontconfig[VERSION],libfreetype[VERSION],libfribidi[VERSION],libfuse[VERSION],libgcc[VERSION],libgcrypt[VERSION],libgdbm[VERSION],libgdk-pixbuf[VERSION],libgeoip[VERSION],libgirepository[VERSION],libglib[VERSION],libglib[VERSION]-data[VERSION],libgmp[VERSION],libgnutls[VERSION],libgnutls-openssl[VERSION],libgpg-error[VERSION],libgpm[VERSION],libgraphite[VERSION],libgssapi-krb[VERSION],libgssapi[VERSION]-heimdal[VERSION],libgtk[VERSION],libguestfs[VERSION],libguestfs-hfsplus[VERSION],libguestfs-perl[VERSION],libguestfs-reiserfs[VERSION],libguestfs-tools[VERSION],libguestfs-xfs[VERSION],libharfbuzz0b[VERSION],libhcrypto[VERSION]-heimdal[VERSION],libheimbase[VERSION]-heimdal[VERSION],libheimntlm0-heimdal[VERSION],libhfsp[VERSION],libhivex[VERSION],libhogweed[VERSION],libhtml-form-perl[VERSION],libhtml-format-perl[VERSION],libhtml-parser-perl[VERSION],libhtml-tagset-perl[VERSION],libhtml-tree-perl[VERSION],libhttp-cookies-perl[VERSION],libhttp-daemon-perl[VERSION],libhttp-date-perl[VERSION],libhttp-message-perl[VERSION],libhttp-negotiate-perl[VERSION],libhx509-5-heimdal[VERSION],libicu[VERSION],libidn[VERSION],libintl-perl[VERSION],libio-html-perl[VERSION],libio-socket-ssl-perl[VERSION],libisc[VERSION],libisc-export[VERSION],libisccc[VERSION],libisccfg[VERSION],libiscsi[VERSION],libjbig[VERSION],libjpeg[VERSION],libjpeg-turbo[VERSION],libjson-c[VERSION],libk5crypto[VERSION],libkeyutils[VERSION],libklibc[VERSION],libkmod[VERSION],libkrb[VERSION],libkrb[VERSION]-heimdal[VERSION],libkrb5support[VERSION],libldap[VERSION],liblocale-gettext-perl[VERSION],liblvm2app[VERSION],liblvm2cmd[VERSION],liblwp-mediatypes-perl[VERSION],liblwp-protocol-https-perl[VERSION],liblwres[VERSION],liblxc[VERSION],liblz[VERSION],liblzma[VERSION],liblzo[VERSION],libmagic[VERSION],libmailtools-perl[VERSION],libmnl[VERSION],libmount[VERSION],libmpdec[VERSION],libmpfr[VERSION],libmspack[VERSION],libncurses[VERSION],libncursesw[VERSION],libnet-http-perl[VERSION],libnet-smtp-ssl-perl[VERSION],libnet-ssleay-perl[VERSION],libnetfilter-conntrack[VERSION],libnettle[VERSION],libnewt[VERSION],libnfnetlink[VERSION],libnih[VERSION],libnl[VERSION],libnl-genl[VERSION],libnspr[VERSION],libnss[VERSION],libnss3-nssdb[VERSION],libnuma[VERSION],libogg[VERSION],libopus[VERSION],libp11-kit[VERSION],libpam-modules[VERSION],libpam-runtime[VERSION],libpam-systemd[VERSION],libpam0g[VERSION],libpango[VERSION],libpangocairo[VERSION],libpangoft[VERSION],libparted[VERSION],libpcap[VERSION],libpci[VERSION],libpcre[VERSION],libperl[VERSION],libpipeline[VERSION],libpixman[VERSION],libplymouth[VERSION],libpng[VERSION],libpolkit-agent[VERSION],libpolkit-backend[VERSION],libpolkit-gobject[VERSION],libpopt[VERSION],libprocps[VERSION],libpulse[VERSION],librados[VERSION],librbd[VERSION],libreadline[VERSION],libroken[VERSION]-heimdal[VERSION],librtmp[VERSION],libsasl[VERSION],libsasl[VERSION]-modules[VERSION],libsasl[VERSION]-modules-db[VERSION],libsdl[VERSION]debian[VERSION],libseccomp[VERSION],libselinux[VERSION],libsemanage[VERSION],libsepol[VERSION],libsigsegv[VERSION],libslang[VERSION],libsmartcols[VERSION],libsndfile[VERSION],libspice-server[VERSION],libsqlite[VERSION],libss[VERSION],libstdc++[VERSION],libstring-shellquote-perl[VERSION],libsys-virt-perl[VERSION],libsystemd[VERSION],libtasn[VERSION],libtext-charwidth-perl[VERSION],libtext-iconv-perl[VERSION],libtext-wrapi18n-perl[VERSION],libthai[VERSION],libthai-data[VERSION],libtiff[VERSION],libtimedate-perl[VERSION],libtinfo[VERSION],libudev[VERSION],liburi-perl[VERSION],libusb[VERSION],libusbredirparser[VERSION],libustr[VERSION],libutempter[VERSION],libuuid[VERSION],libvirt[VERSION],libvorbis0a[VERSION],libvorbisenc[VERSION],libwin-hivex-perl[VERSION],libwind0-heimdal[VERSION],libwrap[VERSION],libwww-perl[VERSION],libwww-robotrules-perl[VERSION],libx[VERSION],libx11-data[VERSION],libxau[VERSION],libxcb[VERSION],libxcb-render[VERSION],libxcb-shm[VERSION],libxcomposite[VERSION],libxcursor[VERSION],libxdamage[VERSION],libxdmcp[VERSION],libxen[VERSION],libxenstore[VERSION],libxext[VERSION],libxfixes[VERSION],libxi[VERSION],libxinerama[VERSION],libxml[VERSION],libxml-parser-perl[VERSION],libxml-xpath-perl[VERSION],libxmuu[VERSION],libxrandr[VERSION],libxrender[VERSION],libxtables[VERSION],libyajl[VERSION],linux[VERSION],linux-firmware[VERSION],linux-headers[VERSION],linux-image[VERSION],linux-image-extra[VERSION],locales[VERSION],login[VERSION],logrotate[VERSION],lsb[VERSION],lsb-release[VERSION],lshw[VERSION],lsof[VERSION],lsscsi[VERSION],ltrace[VERSION],lvm[VERSION],lxc[VERSION],lxcfs[VERSION],lxd[VERSION],lxd-client[VERSION],lzop[VERSION],makedev[VERSION],man-db[VERSION],manpages[VERSION],mawk[VERSION],mdadm[VERSION],mime-support[VERSION],mlocate[VERSION],mount[VERSION],msr-tools[VERSION],mtools[VERSION],mtr-tiny[VERSION],multiarch-support[VERSION],nano[VERSION],ncurses[VERSION],net-tools[VERSION],netbase[VERSION],netcat[VERSION],netcat[VERSION]-openbsd[VERSION],netcat[VERSION]-traditional[VERSION],nmap[VERSION]-ncat[VERSION],ntfs-3g[VERSION],open-iscsi[VERSION],open-vm-tools[VERSION],openssh[VERSION]-client[VERSION],openssh[VERSION]-server[VERSION],openssh[VERSION]-sftp[VERSION]-client[VERSION],openssh[VERSION]-sftp[VERSION]-server[VERSION],os-prober[VERSION],overlayroot[VERSION],parted[VERSION],passwd[VERSION],pastebinit[VERSION],patch[VERSION],pciutils[VERSION],perl[VERSION],perl[VERSION]-base[VERSION],php[VERSION]-common[VERSION],plymouth[VERSION],plymouth-theme-ubuntu-text[VERSION],policykit[VERSION],popularity-contest[VERSION],powermgmt[VERSION],procps[VERSION],psmisc[VERSION],py[VERSION]-pip[VERSION],python,python2[VERSION],python[VERSION]-pip[VERSION],qemu-block-extra[VERSION],qemu-system[VERSION],qemu-system-x[VERSION],qemu-utils[VERSION],readline[VERSION],redhat-logos[VERSION],redhat-rpm-config[VERSION],redhat-upgrade-tool[VERSION],reiserfsprogs[VERSION],rename[VERSION],resolvconf[VERSION],rpm[VERSION],rpm-build[VERSION],rpm-libs[VERSION],rpm-python[VERSION],rpmforge-release[VERSION],rsync[VERSION],rsyslog[VERSION],run-one[VERSION],screen[VERSION],scrub[VERSION],seabios[VERSION],sed[VERSION],sensible-utils[VERSION],sgml[VERSION],shared-mime-info[VERSION],sharutils[VERSION],snap-confine[VERSION],snapd[VERSION],software-properties[VERSION],sosreport[VERSION],squashfs-tools[VERSION],strace[VERSION],sudo[VERSION],supermin[VERSION],supervisor[VERSION],syslinux[VERSION],systemd[VERSION],systemd-sysv[VERSION],sysv-rc[VERSION],sysvinit-utils[VERSION],tar[VERSION],tasksel[VERSION],tasksel-data[VERSION],tcpd[VERSION],tcpdump[VERSION],telnet[VERSION],time[VERSION],tmux[VERSION],tzdata[VERSION],ubuntu-cloudimage-keyring[VERSION],ubuntu-core-launcher[VERSION],ubuntu-keyring[VERSION],ubuntu-minimal[VERSION],ubuntu-release-upgrader-core[VERSION],ubuntu-server[VERSION],ubuntu-standard[VERSION],ucf[VERSION],udev[VERSION],ufw[VERSION],uidmap[VERSION],unattended-upgrades[VERSION],unzip[VERSION],update-manager-core[VERSION],update-notifier[VERSION],ureadahead[VERSION],usbutils[VERSION],util-linux[VERSION],uuid-runtime[VERSION],vim[VERSION],vim-runtime[VERSION],vim-tiny[VERSION],vlan[VERSION],wget[VERSION],whiptail[VERSION],wireless-regdb[VERSION],xauth[VERSION],xdg-user-dirs[VERSION],xfsprogs[VERSION],xkb-data[VERSION],xml-core[VERSION],xz-utils[VERSION],yum[VERSION],yum-metadata-parser[VERSION],yum-plugin-fastestmirror[VERSION],yum-plugin-replace[VERSION],yum-plugin-security[VERSION],yum-utils[VERSION],zerofree[VERSION],zlib1g[VERSION]";

        static void Main()
        {
            for (int i = 0; i < 5; i++)
            {
                Test();
            }
        }

        static void Test()
        {
            var regex = new Regex(
                @"^ActiveMQ[\d\.-]*$",
                RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);

            var sw = Stopwatch.StartNew();

            var packageCategories = PackageProcessor.GetPackageCategories(FilterString.Split(","));
            var packageInfos = PackageProcessor.GetPackageInfos(PackageString.Split(","), packageCategories);

            Console.WriteLine(sw.Elapsed + "|" + packageInfos.Count);
        }
    }
}
